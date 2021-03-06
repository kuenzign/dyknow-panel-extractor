﻿// <copyright file="Link.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The link object.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The link object.
    /// </summary>
    [XmlRoot("LINK")]
    public class Link
    {
        /// <summary>
        /// The cr value.
        /// </summary>
        private string cr;

        /// <summary>
        /// The ut value.
        /// </summary>
        private int ut;

        /// <summary>
        /// The tn value.
        /// </summary>
        private int tn;

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
        /// The path value.
        /// </summary>
        private string path;

        /// <summary>
        /// The alias value.
        /// </summary>
        private string alias;

        /// <summary>
        /// The usset value.
        /// </summary>
        private bool usett;

        /// <summary>
        /// Initializes a new instance of the <see cref="Link"/> class.
        /// </summary>
        public Link()
        {
        }

        /// <summary>
        /// Gets or sets the CR.
        /// </summary>
        /// <value>The CR value.</value>
        [XmlAttribute("CR")]
        public string CR
        {
            get { return this.cr; }
            set { this.cr = value; }
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
        /// Gets or sets the TN.
        /// </summary>
        /// <value>The TN value.</value>
        [XmlAttribute("TN")]
        public int TN
        {
            get { return this.tn; }
            set { this.tn = value; }
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
        /// Gets or sets the Path.
        /// </summary>
        /// <value>The Path value.</value>
        [XmlElement("PATH")]
        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        /// <summary>
        /// Gets or sets the Alias.
        /// </summary>
        /// <value>The Alias value.</value>
        [XmlElement("ALIAS")]
        public string Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Link"/> is USETT.
        /// </summary>
        /// <value><c>true</c> if USETT; otherwise, <c>false</c>.</value>
        [XmlElement("USETT")]
        public bool USETT
        {
            get { return this.usett; }
            set { this.usett = value; }
        }
    }
}