﻿// <copyright file="WebPanel.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The web panel object.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The web panel object.
    /// </summary>
    [XmlRoot("WEBPNL")]
    public class WebPanel
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
        private string uid;

        /// <summary>
        /// The pos value.
        /// </summary>
        private int pos;

        /// <summary>
        /// The cap value.
        /// </summary>
        private bool cap;

        /// <summary>
        /// The url value.
        /// </summary>
        private string url;

        /// <summary>
        /// The capimg value.
        /// </summary>
        private Capimg capimg;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPanel"/> class.
        /// </summary>
        public WebPanel()
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
        public string UID
        {
            get { return this.uid; }
            set { this.uid = value; }
        }

        /// <summary>
        /// Gets or sets the POS.
        /// </summary>
        /// <value>The POS value.</value>
        [XmlAttribute("POS")]
        public int POS
        {
            get { return this.pos; }
            set { this.pos = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebPanel"/> is CAP.
        /// </summary>
        /// <value><c>true</c> if CAP; otherwise, <c>false</c>.</value>
        [XmlAttribute("CAP")]
        public bool CAP
        {
            get { return this.cap; }
            set { this.cap = value; }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL value.</value>
        [XmlAttribute("URL")]
        public string URL
        {
            get { return this.url; }
            set { this.url = value; }
        }

        /// <summary>
        /// Gets or sets the CAPIMG.
        /// </summary>
        /// <value>The CAPIMG value.</value>
        [XmlElement("CAPIMG")]
        public Capimg CAPIMG
        {
            get { return this.capimg; }
            set { this.capimg = value; }
        }
    }
}