﻿// <copyright file="Mrgn.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The mrgn object.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Collections;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The mrgn object.
    /// </summary>
    [XmlRoot("MRGN")]
    public class Mrgn
    {
        /// <summary>
        /// The bkgr value.
        /// </summary>
        private Guid bkgr;

        /// <summary>
        /// The objects list of objects.
        /// </summary>
        private ArrayList objects;

        /// <summary>
        /// The txtmodecontentsmod value.
        /// </summary>
        private string txtmodecontentsmod;

        /// <summary>
        /// The txtmodecontentspart value.
        /// </summary>
        private string txtmodecontentspart;

        /// <summary>
        /// The txtmodemodxaml value.
        /// </summary>
        private string txtmodemodxaml;

        /// <summary>
        /// The txtmodepartxaml value.
        /// </summary>
        private string txtmodepartxaml;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mrgn"/> class.
        /// </summary>
        public Mrgn()
        {
            this.objects = new ArrayList();
            this.txtmodecontentsmod = string.Empty;
            this.txtmodecontentspart = string.Empty;
            this.txtmodemodxaml = string.Empty;
            this.txtmodepartxaml = string.Empty;
        }

        /// <summary>
        /// Gets or sets the BKGR.
        /// </summary>
        /// <value>The BKGR value.</value>
        [XmlAttribute("BKGR")]
        public Guid BKGR
        {
            get { return this.bkgr; }
            set { this.bkgr = value; }
        }

        /// <summary>
        /// Gets or sets the Objects.
        /// </summary>
        /// <value>The Objects list of objects.</value>
        [XmlArray("OLST")]
        [XmlArrayItem("PEN", typeof(Pen), IsNullable = true)]
        [XmlArrayItem("IMG", typeof(Image), IsNullable = true)]
        [XmlArrayItem("GRP", typeof(Group), IsNullable = true)]
        [XmlArrayItem("DEOB", typeof(Deob), IsNullable = true)]
        [XmlArrayItem("EDOB", typeof(Edob), IsNullable = true)]
        [XmlArrayItem("WEBPNL", typeof(WebPanel), IsNullable = true)]
        [XmlArrayItem("RTEXT", typeof(Rtext), IsNullable = true)]
        [XmlArrayItem("LINK", typeof(Link), IsNullable = true)]
        [XmlArrayItem("EPOLL", typeof(Epoll), IsNullable = true)]
        [XmlArrayItem("ABOX", typeof(AnswerBox), IsNullable = true)]
        [XmlArrayItem("TBLE", typeof(Table), IsNullable = true)]
        [XmlArrayItem("PGNAV", typeof(Pgnav), IsNullable = true)]
        public ArrayList Objects
        {
            get { return this.objects; }
            set { this.objects = value; }
        }

        /// <summary>
        /// Gets or sets the TXTMODECONTENTSMOD.
        /// </summary>
        /// <value>The TXTMODECONTENTSMOD value.</value>
        [XmlElement("TXTMODECONTENTSMOD")]
        public string TXTMODECONTENTSMOD
        {
            get { return this.txtmodecontentsmod; }
            set { this.txtmodecontentsmod = value; }
        }

        /// <summary>
        /// Gets or sets the TXTMODECONTENTSPART.
        /// </summary>
        /// <value>The TXTMODECONTENTSPART value.</value>
        [XmlElement("TXTMODECONTENTSPART")]
        public string TXTMODECONTENTSPART
        {
            get { return this.txtmodecontentspart; }
            set { this.txtmodecontentspart = value; }
        }

        /// <summary>
        /// Gets or sets the TXTMODEMODXAML.
        /// </summary>
        /// <value>The TXTMODEMODXAML value.</value>
        [XmlElement("TXTMODEMODXAML")]
        public string TXTMODEMODXAML
        {
            get { return this.txtmodemodxaml; }
            set { this.txtmodemodxaml = value; }
        }

        /// <summary>
        /// Gets or sets the TXTMODEPARTXAML.
        /// </summary>
        /// <value>The TXTMODEPARTXAML value.</value>
        [XmlElement("TXTMODEPARTXAML")]
        public string TXTMODEPARTXAML
        {
            get { return this.txtmodepartxaml; }
            set { this.txtmodepartxaml = value; }
        }
    }
}