// <copyright file="Page.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The page that contains all of the panel information.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Documents;
    using System.Windows.Markup;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The page that contains all of the panel information.
    /// </summary>
    [XmlRoot("PAGE")]
    public class Page
    {
        /// <summary>
        /// The page version number.
        /// </summary>
        private string version;

        /// <summary>
        /// The uid value.
        /// </summary>
        private Guid uid;

        /// <summary>
        /// The cfsm value.
        /// </summary>
        private string cfsm;

        /// <summary>
        /// The bkgr value.
        /// </summary>
        private string bkgr;

        /// <summary>
        /// The cfsp value.
        /// </summary>
        private string cfsp;

        /// <summary>
        /// The ownerUserName value;
        /// </summary>
        private string ownerUserName;

        /// <summary>
        /// The ownerFullName value.
        /// </summary>
        private string ownerFullName;

        /// <summary>
        /// The animations list of objects.
        /// </summary>
        private ArrayList animations;

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
        private FlowDocument txtmodemodxaml;

        /// <summary>
        /// The txtmodepartxaml value.
        /// </summary>
        private FlowDocument txtmodepartxaml;

        /// <summary>
        /// The objects list of objects.
        /// </summary>
        private ArrayList objects;

        /// <summary>
        /// The ulst object.
        /// </summary>
        private Ulst ulst;

        /// <summary>
        /// The nlst object.
        /// </summary>
        private Nlst nlst;

        /// <summary>
        /// The mrgn object.
        /// </summary>
        private Mrgn mrgn;

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        public Page()
        {
            this.animations = new ArrayList();
            this.objects = new ArrayList();
            this.ulst = null;
            this.nlst = null;
            this.mrgn = null;
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
        /// Gets or sets the CFSM.
        /// </summary>
        /// <value>The CFSM value.</value>
        [XmlAttribute("CFSM")]
        public string CFSM
        {
            get { return this.cfsm; }
            set { this.cfsm = value; }
        }

        /// <summary>
        /// Gets or sets the BKGR.
        /// </summary>
        /// <value>The BKGR value.</value>
        [XmlAttribute("BKGR")]
        public string BKGR
        {
            get { return this.bkgr; }
            set { this.bkgr = value; }
        }

        /// <summary>
        /// Gets or sets the CFSP.
        /// </summary>
        /// <value>The CFSP value.</value>
        [XmlAttribute("CFSP")]
        public string CFSP
        {
            get { return this.cfsp; }
            set { this.cfsp = value; }
        }

        /// <summary>
        /// Gets or sets the OwnerUserName.
        /// </summary>
        /// <value>The OwnerUserName value.</value>
        [XmlAttribute("ONER")]
        public string OwnerUserName
        {
            get { return this.ownerUserName; }
            set { this.ownerUserName = value; }
        }

        /// <summary>
        /// Gets or sets the OwnerFullName.
        /// </summary>
        /// <value>The OwnerFullName value.</value>
        [XmlAttribute("ONERN")]
        public string OwnerFullName
        {
            get { return this.ownerFullName; }
            set { this.ownerFullName = value; }
        }

        /// <summary>
        /// Gets or sets the Animations.
        /// </summary>
        /// <value>The Animations value.</value>
        [XmlArray("ANIMLIST")]
        [XmlArrayItem("A", typeof(Animation), IsNullable = true)]
        public ArrayList Animations
        {
            get { return this.animations; }
            set { this.animations = value; }
        }

        /// <summary>
        /// Gets or sets the TXTMODECONTENTSMOD.
        /// </summary>
        /// <value>The TXTMODECONTENTSMOD value.</value>
        [XmlElement("TXTMODECONTENTSMOD")]
        public string TXTMODECONTENTSMOD
        {
            get
            {
                return this.txtmodecontentsmod;
            }

            set
            {
                this.txtmodecontentsmod = value;
            }
        }

        /// <summary>
        /// Gets or sets the TXTMODECONTENTSPART.
        /// </summary>
        /// <value>The TXTMODECONTENTSPART value.</value>
        [XmlElement("TXTMODECONTENTSPART")]
        public string TXTMODECONTENTSPART
        {
            get
            {
                return this.txtmodecontentspart;
            }

            set
            {
                this.txtmodecontentspart = value;
            }
        }

        /// <summary>
        /// Gets or sets the TXTMODEMODXAML.
        /// </summary>
        /// <value>The TXTMODEMODXAML value.</value>
        [XmlElement("TXTMODEMODXAML")]
        public string TXTMODEMODXAML
        {
            get
            {
                if (this.txtmodemodxaml == null)
                {
                    return string.Empty;
                }
                else
                {
                    return XamlWriter.Save(this.txtmodemodxaml);
                }
            }

            set
            {
                if (value.Length > 0)
                {
                    this.txtmodemodxaml = new FlowDocument();
                    byte[] byteArray = Encoding.ASCII.GetBytes(value);
                    MemoryStream stream = new MemoryStream(byteArray);
                    this.txtmodemodxaml = XamlReader.Load(stream) as FlowDocument;
                }
            }
        }

        /// <summary>
        /// Gets or sets the TXTMODEPARTXAML.
        /// </summary>
        /// <value>The TXTMODEPARTXAML value.</value>
        [XmlElement("TXTMODEPARTXAML")]
        public string TXTMODEPARTXAML
        {
            get
            {
                if (this.txtmodepartxaml == null)
                {
                    return string.Empty;
                }
                else
                {
                    return XamlWriter.Save(this.txtmodepartxaml);
                }
            }

            set
            {
                if (value.Length > 0)
                {
                    this.txtmodepartxaml = new FlowDocument();
                    byte[] byteArray = Encoding.ASCII.GetBytes(value);
                    MemoryStream stream = new MemoryStream(byteArray);
                    this.txtmodepartxaml = XamlReader.Load(stream) as FlowDocument;
                }
            }
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
        /// Gets or sets the ULST.
        /// </summary>
        /// <value>The ULST value.</value>
        [XmlElement("ULST")]
        public Ulst ULST
        {
            get { return this.ulst; }
            set { this.ulst = value; }
        }

        /// <summary>
        /// Gets or sets the NLST.
        /// </summary>
        /// <value>The NLST value.</value>
        [XmlElement("NLST")]
        public Nlst NLST
        {
            get { return this.nlst; }
            set { this.nlst = value; }
        }

        /// <summary>
        /// Gets or sets the MRGN.
        /// </summary>
        /// <value>The MRGN value.</value>
        [XmlElement("MRGN")]
        public Mrgn MRGN
        {
            get { return this.mrgn; }
            set { this.mrgn = value; }
        }

        // Custom elements that are not serialized / deserialized

        /// <summary>
        /// Gets the list of images.
        /// </summary>
        /// <value>The list of images.</value>
        [XmlIgnore]
        internal ArrayList CustomImages
        {
            get
            {
                ArrayList arr = new ArrayList();
                for (int i = 0; i < this.objects.Count; i++)
                {
                    if (this.objects[i].GetType().Equals(typeof(Image)))
                    {
                        arr.Add(this.objects[i]);
                    }
                }

                return arr;
            }
        }

        /// <summary>
        /// Gets the list of ink strokes.
        /// </summary>
        /// <value>The list of ink strokes.</value>
        [XmlIgnore]
        internal ArrayList CustomInkStrokes
        {
            get
            {
                ArrayList arr = new ArrayList();
                for (int i = 0; i < this.objects.Count; i++)
                {
                    if (this.objects[i].GetType().Equals(typeof(Pen)))
                    {
                        arr.Add(this.objects[i]);
                    }
                }

                return arr;
            }
        }

        /// <summary>
        /// Gets the answer boxes.
        /// </summary>
        /// <value>The answer boxes.</value>
        [XmlIgnore]
        internal ArrayList AnswerBoxes
        {
            get
            {
                ArrayList arr = new ArrayList();
                for (int i = 0; i < this.objects.Count; i++)
                {
                    if (this.objects[i].GetType().Equals(typeof(AnswerBox)))
                    {
                        arr.Add(this.objects[i]);
                    }
                }

                return arr;
            }
        }

        /// <summary>
        /// Determines whether the specified object is deleted.
        /// </summary>
        /// <param name="id">The object identifier.</param>
        /// <returns><c>true</c> if specified object is deleted; otherwise, <c>false</c>.</returns>
        internal bool IsObjectDeleted(Guid id)
        {
            for (int i = 0; i < this.objects.Count; i++)
            {
                if (this.objects[i].GetType().Equals(typeof(Deob)))
                {
                    Deob d = this.objects[i] as Deob;
                    if (d.Contains(id))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}