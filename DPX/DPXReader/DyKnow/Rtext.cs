// <copyright file="Rtext.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The rtext object.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The rtext object.
    /// </summary>
    [XmlRoot("RTEXT")]
    public class Rtext
    {
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
        /// The version value.
        /// </summary>
        private string version;

        /// <summary>
        /// The ani value.
        /// </summary>
        private string ani;

        /// <summary>
        /// The rtf value.
        /// </summary>
        private string rtf;

        /// <summary>
        /// The xaml value.
        /// </summary>
        private string xaml;

        /// <summary>
        /// The width value.
        /// </summary>
        private int width;

        /// <summary>
        /// The height value.
        /// </summary>
        private int height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rtext"/> class.
        /// </summary>
        public Rtext()
        {
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
        /// Gets or sets the ANI.
        /// </summary>
        /// <value>The ANI value.</value>
        [XmlAttribute("ANI")]
        public string ANI
        {
            get { return this.ani; }
            set { this.ani = value; }
        }

        /// <summary>
        /// Gets or sets the RTF.
        /// </summary>
        /// <value>The RTF value.</value>
        [XmlElement("RTF")]
        public string RTF
        {
            get { return this.rtf; }
            set { this.rtf = value; }
        }

        /// <summary>
        /// Gets or sets the XAML.
        /// </summary>
        /// <value>The XAML value.</value>
        [XmlElement("XAML")]
        public string XAML
        {
            get { return this.xaml; }
            set { this.xaml = value; }
        }

        /// <summary>
        /// Gets or sets the Width.
        /// </summary>
        /// <value>The Width value.</value>
        [XmlElement("WID")]
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets the Height.
        /// </summary>
        /// <value>The Height value.</value>
        [XmlElement("HEI")]
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
    }
}