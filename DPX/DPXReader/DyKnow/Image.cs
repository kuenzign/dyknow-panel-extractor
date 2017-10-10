// <copyright file="Image.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The reference to an image contained on a panel.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The reference to an image contained on a panel.
    /// </summary>
    [XmlRoot("IMG")]
    public class Image
    {
        /// <summary>
        /// The reference width used to transform the image dimensions.
        /// </summary>
        private const int ReferenceWidth = 27100;

        /// <summary>
        /// The reference height used to transform the image dimensions.
        /// </summary>
        private const int ReferenceHeight = 20325;

        /// <summary>
        /// The ut value.
        /// </summary>
        private int ut;

        /// <summary>
        /// The sp value.
        /// </summary>
        private string sp;

        /// <summary>
        /// The pageWidth value.
        /// </summary>
        private int pageWidth;

        /// <summary>
        /// The pageHeight value.
        /// </summary>
        private int pageHeight;

        /// <summary>
        /// The uid value.
        /// </summary>
        private Guid uid;

        /// <summary>
        /// The id value.
        /// </summary>
        private Guid id;

        /// <summary>
        /// The width value.
        /// </summary>
        private int width;

        /// <summary>
        /// The height value.
        /// </summary>
        private int height;

        /// <summary>
        /// The slideText value;
        /// </summary>
        private string slideText;

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        public Image()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="ut">The ut value.</param>
        /// <param name="sp">The sp value.</param>
        /// <param name="pageWidth">The pageWidth value.</param>
        /// <param name="pageHeight">The pageHeight value.</param>
        /// <param name="uid">The uid value.</param>
        /// <param name="id">The id value.</param>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        public Image(int ut, string sp, int pageWidth, int pageHeight, Guid uid, Guid id, int width, int height)
        {
            this.ut = ut;
            this.sp = sp;
            this.pageWidth = pageWidth;
            this.pageHeight = pageHeight;
            this.uid = uid;
            this.id = id;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets or sets the UT.
        /// </summary>
        /// <value>The UT value.</value>
        [XmlAttribute("UT")]
        public int UT
        {
            get { return this.ut; }
            set { this.ut = value; }
        }

        /// <summary>
        /// Gets or sets the SP.
        /// </summary>
        /// <value>The SP value.</value>
        [XmlAttribute("SP")]
        public string SP
        {
            get { return this.sp; }
            set { this.sp = value; }
        }

        /// <summary>
        /// Gets or sets the PageWidth.
        /// </summary>
        /// <value>The PageWidth value.</value>
        [XmlAttribute("PW")]
        public int PageWidth
        {
            get { return this.pageWidth; }
            set { this.pageWidth = value; }
        }

        /// <summary>
        /// Gets or sets the PageHeight.
        /// </summary>
        /// <value>The PageHeight value.</value>
        [XmlAttribute("PH")]
        public int PageHeight
        {
            get { return this.pageHeight; }
            set { this.pageHeight = value; }
        }

        /// <summary>
        /// Gets or sets the UID.
        /// </summary>
        /// <value>The UID value.</value>
        [XmlAttribute("UID")]
        public Guid UID
        {
            get { return this.uid; }
            set { this.uid = value; }
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID value.</value>
        [XmlAttribute("ID")]
        public Guid ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets the Width.
        /// </summary>
        /// <value>The Width value.</value>
        [XmlAttribute("WID")]
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets the Height.
        /// </summary>
        /// <value>The Height value.</value>
        [XmlAttribute("HEI")]
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Gets or sets the SlideText.
        /// </summary>
        /// <value>The SlideText.</value>
        [XmlElement("SLIDETXT")]
        public string SlideText
        {
            get { return this.slideText; }
            set { this.slideText = value; }
        }

        // Custom, non serialized attributes

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        /// <value>The width of the image.</value>
        [XmlIgnore]
        internal double CustomImageWidth
        {
            get { return (double)this.width / (double)Image.ReferenceWidth; }
        }

        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        /// <value>The height of the image.</value>
        [XmlIgnore]
        internal double CustomImageHeight
        {
            get { return (double)this.height / (double)Image.ReferenceHeight; }
        }

        /// <summary>
        /// Gets the left position for the image.
        /// </summary>
        /// <value>The left position.</value>
        [XmlIgnore]
        internal double CustomPositionLeft
        {
            get
            {
                int start = 0;
                int end = this.sp.IndexOf(':');
                string val = this.sp.Substring(start, end);
                double num = int.Parse(val);
                return num / Image.ReferenceWidth;
            }
        }

        /// <summary>
        /// Gets the top position for the image.
        /// </summary>
        /// <value>The top position.</value>
        [XmlIgnore]
        internal double CustomPositionTop
        {
            get
            {
                int start = this.sp.IndexOf(':') + 1;
                string val = this.sp.Substring(start);
                double num = int.Parse(val);
                return num / Image.ReferenceHeight;
            }
        }
    }
}