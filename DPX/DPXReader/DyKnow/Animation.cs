// <copyright file="Animation.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The animation object.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The animation object.
    /// </summary>
    [XmlRoot("A")]
    public class Animation
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
        /// The tb value.
        /// </summary>
        private Guid tb;

        /// <summary>
        /// The type value.
        /// </summary>
        private int type;

        /// <summary>
        /// The par value.
        /// </summary>
        private int par;

        /// <summary>
        /// The level value.
        /// </summary>
        private int level;

        /// <summary>
        /// The xaml value.
        /// </summary>
        private string xaml;

        /// <summary>
        /// Initializes a new instance of the <see cref="Animation"/> class.
        /// </summary>
        public Animation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animation"/> class.
        /// </summary>
        /// <param name="ut">The ut value.</param>
        /// <param name="pageWidth">The pageWidth value.</param>
        /// <param name="pageHeight">The pageHeight value.</param>
        /// <param name="uid">The uid value.</param>
        /// <param name="tb">The tb value.</param>
        /// <param name="type">The type value.</param>
        /// <param name="par">The par value.</param>
        /// <param name="level">The Level value.</param>
        public Animation(int ut, int pageWidth, int pageHeight, Guid uid, Guid tb, int type, int par, int level)
        {
            this.ut = ut;
            this.pageWidth = pageWidth;
            this.pageHeight = pageHeight;
            this.uid = uid;
            this.tb = tb;
            this.type = type;
            this.par = par;
            this.level = level;
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
        /// Gets or sets the TB.
        /// </summary>
        /// <value>The TB value.</value>
        [XmlAttribute("TB")]
        public Guid TB
        {
            get { return this.tb; }
            set { this.tb = value; }
        }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        /// <value>The Type value.</value>
        [XmlAttribute("TYP")]
        public int Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Gets or sets the PAR.
        /// </summary>
        /// <value>The PAR value.</value>
        [XmlAttribute("PAR")]
        public int PAR
        {
            get { return this.par; }
            set { this.par = value; }
        }

        /// <summary>
        /// Gets or sets the Level.
        /// </summary>
        /// <value>The Level value.</value>
        [XmlAttribute("LVL")]
        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
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
    }
}