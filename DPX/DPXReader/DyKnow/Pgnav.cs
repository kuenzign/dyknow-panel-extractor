// <copyright file="Pgnav.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The representation of a pgnav.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The representation of a pgnav.
    /// </summary>
    public class Pgnav
    {
        /// <summary>
        /// The ut value.
        /// </summary>
        private int ut;

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
        /// The ati value.
        /// </summary>
        private string ati;

        /// <summary>
        /// The pageGuid.
        /// </summary>
        private Guid pageGuid;

        /// <summary>
        /// The type value.
        /// </summary>
        private int type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pgnav"/> class.
        /// </summary>
        public Pgnav()
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
        /// Gets or sets the ATI.
        /// </summary>
        /// <value>The ATI value.</value>
        [XmlAttribute("ATI")]
        public string ATI
        {
            get { return this.ati; }
            set { this.ati = value; }
        }

        /// <summary>
        /// Gets or sets the PageGuid.
        /// </summary>
        /// <value>The PageGuid value.</value>
        [XmlElement("PGGUID")]
        public Guid PageGuid
        {
            get { return this.pageGuid; }
            set { this.pageGuid = value; }
        }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        /// <value>The Type value.</value>
        [XmlElement("TYPE")]
        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}