// <copyright file="DyKnow.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>A representation of a DyKnow file.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Collections;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Ink;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// A representation of a DyKnow file.
    /// </summary>
    [XmlRoot("DYKNOW_NB50")]
    public class DyKnow
    {
        /// <summary>
        /// The aid value.
        /// </summary>
        private string aid;

        /// <summary>
        /// The version value.
        /// </summary>
        private string version;

        /// <summary>
        /// The pages list.
        /// </summary>
        private ArrayList pages;

        /// <summary>
        /// The images list.
        /// </summary>
        private ArrayList images;

        /// <summary>
        /// The imageIds list.
        /// </summary>
        private ArrayList imageIds;

        /// <summary>
        /// The chat list of objects.
        /// </summary>
        private ArrayList chatMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="DyKnow"/> class.
        /// </summary>
        public DyKnow()
        {
            this.pages = new ArrayList();
            this.chatMessages = new ArrayList();
        }

        /// <summary>
        /// Gets or sets the AID.
        /// </summary>
        /// <value>The AID value.</value>
        [XmlAttribute("AID")]
        public string AID
        {
            get { return this.aid; }
            set { this.aid = value; }
        }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        /// <value>The Version value.</value>
        [XmlAttribute("VRSN")]
        public string Version
        {
            get { return this.version; }
            set { this.version = value; }
        }

        /// <summary>
        /// Gets or sets the Pages.
        /// </summary>
        /// <value>The Pages list.</value>
        [XmlArray("DATA")]
        [XmlArrayItem("PAGE", typeof(Page))]
        public ArrayList Pages
        {
            get { return this.pages; }
            set { this.pages = value; }
        }

        /// <summary>
        /// Gets or sets the Images.
        /// </summary>
        /// <value>The Images list.</value>
        [XmlArray("IMGS")]
        [XmlArrayItem("IMG", typeof(string))]
        public ArrayList Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        /// <summary>
        /// Gets or sets the ImageIDs.
        /// </summary>
        /// <value>The ImageIDs list.</value>
        [XmlArray("IMGD")]
        [XmlArrayItem("ID", typeof(Guid))]
        public ArrayList ImageIDs
        {
            get { return this.imageIds; }
            set { this.imageIds = value; }
        }

        /// <summary>
        /// Gets or sets the ChatMessages.
        /// </summary>
        /// <value>The ChatMessages list of objects.</value>
        [XmlArray("CHATS")]
        [XmlArrayItem("MSG", typeof(Message))]
        public ArrayList ChatMessages
        {
            get { return this.chatMessages; }
            set { this.chatMessages = value; }
        }

        /// <summary>
        /// Deserializes the specified pages.
        /// </summary>
        /// <param name="data">The pages to deserialize.</param>
        /// <returns>The instance of the DyKnow class.</returns>
        public static DyKnow Deserialize(string data)
        {
            DyKnow d = SerializerHelper.DeserializeObject(data, typeof(DyKnow)) as DyKnow;
            return d;
        }

        /// <summary>
        /// Deserializes the specified file.
        /// </summary>
        /// <param name="file">The file to load.</param>
        /// <returns>The instance of the DyKnow class.</returns>
        public static DyKnow DeserializeFromFile(string file)
        {
            FileStream inputFile = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            GZipStream gzipFile = new GZipStream(inputFile, CompressionMode.Decompress, true);
            StreamReader reader = new StreamReader(gzipFile);
            string content = reader.ReadToEnd();
            gzipFile.Close();
            inputFile.Close();
            return Deserialize(content);
        }

        /// <summary>
        /// Serializes this instance of DyKnow.
        /// </summary>
        /// <returns>The string representation of the class.</returns>
        public string Serialize()
        {
            // Remember these arrays
            ArrayList s = this.images;
            ArrayList d = this.imageIds;

            // If the arrays are blank set them to null
            if (this.images != null && this.images.Count == 0)
            {
                this.images = null;
            }

            if (this.imageIds != null && this.imageIds.Count == 0)
            {
                this.imageIds = null;
            }

            // Serialize the object
            string str = SerializerHelper.SerializeObject(this, typeof(DyKnow));

            // Restore the arrays
            this.images = s;
            this.imageIds = d;

            // Return the result
            return str;
        }

        /// <summary>
        /// Renders the specified page on the provided InkCanvas.
        /// </summary>
        /// <param name="inky">The InkCanvas to render the page on.</param>
        /// <param name="page">The page number.</param>
        public void Render(InkCanvas inky, int page)
        {
            // Read in the panel
            Page dp = this.pages[page] as Page;

            // Display all of the images and pen strokes
            inky.Strokes.Clear();
            inky.Children.Clear();

            // Add all of the images as children of the InkCanvas
            ArrayList dki = dp.CustomImages;
            for (int i = 0; i < dki.Count; i++)
            {
                Image img = dki[i] as Image;

                // Get the actual image
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(System.Convert.FromBase64String(this.GetImageData(img.ID)));
                bi.EndInit();

                // Sets do some complicated math to get the position and scale factors for the image
                double scaleW = ((img.CustomImageWidth * inky.Width) / bi.Width) * (inky.Width / img.PageWidth);
                double scaleH = ((img.CustomImageHeight * inky.Height) / bi.Height) * (inky.Height / img.PageHeight);
                double left = img.CustomPositionLeft * inky.Width * inky.Width / img.PageWidth;
                double top = img.CustomPositionTop * inky.Height * inky.Height / img.PageHeight;

                // Allows for independent canvas sizes. (Not sure why this was necessary...)
                scaleW = scaleW * 1024 / inky.Width;
                scaleH = scaleH * 768 / inky.Height;
                left = left * 1024 / inky.Width;
                top = top * 768 / inky.Height;

                // Resize the image if it is not the correct size
                TransformedBitmap tb = new TransformedBitmap();
                tb.BeginInit();
                tb.Source = bi;
                ScaleTransform sc = new ScaleTransform(scaleW, scaleH);
                tb.Transform = sc;
                tb.EndInit();

                // Add the image to the canvas
                System.Windows.Controls.Image im = new System.Windows.Controls.Image
                {
                    Source = tb
                };
                inky.Children.Add(im);

                // Set the position on the canvas
                InkCanvas.SetLeft(im, left);
                InkCanvas.SetTop(im, top);
            }

            // Add all of the answer boxes
            ArrayList aboxes = dp.AnswerBoxes;
            for (int i = 0; i < aboxes.Count; i++)
            {
                AnswerBox abox = aboxes[i] as AnswerBox;
                Rectangle r = new Rectangle
                {
                    Fill = Brushes.LightGray
                };
                double left = abox.ActualLeftPosition(inky.Width);
                double top = abox.ActualTopPosition(inky.Height);
                r.Width = abox.ActualWidth(inky.Width);
                r.Height = abox.ActualHeight(inky.Height);
                InkCanvas.SetLeft(r, left);
                InkCanvas.SetTop(r, top);
                inky.Children.Add(r);
            }

            // Get that Panel's pen strokes
            ArrayList pens = dp.CustomInkStrokes;

            // Loop through all of the pen strokes
            for (int i = 0; i < pens.Count; i++)
            {
                Pen p = pens[i] as Pen;

                // Only display the ink if it wasn't deleted
                if (!dp.IsObjectDeleted(p.UID))
                {
                    // The pages is encoded as a string
                    string data = p.Data;

                    // Truncate off the "base64:" from the beginning of the string
                    data = data.Substring(7);

                    // Decode the string
                    byte[] bufferData = Convert.FromBase64String(data);

                    // Turn the string into a stream
                    Stream s = new MemoryStream(bufferData);

                    // Convert the stream into an ink stroke
                    StrokeCollection sc = new StrokeCollection(s);
                    s.Close();

                    // Resize the panel if it is not the default resolution
                    if (p.PageHeight != inky.Height || p.PageWidth != inky.Width)
                    {
                        Matrix inkTransform = new Matrix();
                        inkTransform.Scale(inky.Width / (double)p.PageWidth, inky.Height / (double)p.PageHeight);
                        sc.Transform(inkTransform, true);
                    }

                    // Add the ink stroke to the canvas
                    inky.Strokes.Add(sc);
                }
            }
        }

        /// <summary>
        /// Gets the thumbnail for the specified page.
        /// </summary>
        /// <param name="page">The page to render.</param>
        /// <param name="width">The width of the original InkCanvas.</param>
        /// <param name="height">The height of the original InkCanvas.</param>
        /// <param name="factor">The factor to reduce the image by.</param>
        /// <returns>The rendered thumbnail as an image.</returns>
        public System.Windows.Controls.Image GetThumbnail(int page, double width, double height, double factor)
        {
            InkCanvas ink = new InkCanvas
            {
                Width = width,
                Height = height
            };
            this.Render(ink, page);
            RenderTargetBitmap rtb = new RenderTargetBitmap(Convert.ToInt32(ink.Width), Convert.ToInt32(ink.Height), 96d, 96d, PixelFormats.Default);
            rtb.Render(ink);
            TransformedBitmap tb = new TransformedBitmap(rtb, new ScaleTransform(factor, factor));
            System.Windows.Controls.Image myImage = new System.Windows.Controls.Image
            {
                Source = tb
            };
            return myImage;
        }

        /// <summary>
        /// Gets the answer box thumbnail.
        /// </summary>
        /// <param name="strokes">The strokes.</param>
        /// <param name="width">The panel width.</param>
        /// <param name="height">The panel height.</param>
        /// <param name="rect">The rectangle.</param>
        /// <returns>The image of the answer box.</returns>
        public System.Windows.Controls.Image GetAnswerBoxThumbnail(StrokeCollection strokes, double width, double height, System.Windows.Rect rect)
        {
            InkCanvas ink = new InkCanvas
            {
                Width = width,
                Height = height,
                Strokes = strokes
            };
            RenderTargetBitmap rtb = new RenderTargetBitmap(Convert.ToInt32(ink.Width), Convert.ToInt32(ink.Height), 96d, 96d, PixelFormats.Default);
            rtb.Render(ink);
            System.Windows.Int32Rect intrect = new System.Windows.Int32Rect((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
            CroppedBitmap cb = new CroppedBitmap(rtb, intrect);
            System.Windows.Controls.Image myImage = new System.Windows.Controls.Image
            {
                Source = cb
            };
            return myImage;
        }

        /// <summary>
        /// Gets the image pages.
        /// </summary>
        /// <param name="id">The image identifier.</param>
        /// <returns>The serialized representation of the image.</returns>
        private string GetImageData(Guid id)
        {
            for (int i = 0; i < this.imageIds.Count; i++)
            {
                if (((Guid)this.imageIds[i]).Equals(id))
                {
                    return this.images[i] as string;
                }
            }

            return null;
        }
    }
}