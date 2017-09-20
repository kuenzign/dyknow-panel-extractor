// <copyright file="Answer.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The answer object.</summary>
namespace DPXReader.DyKnow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// The answer object.
    /// </summary>
    [XmlRoot("A")]
    public class Answer
    {
        /// <summary>
        /// The shortAnswer value.
        /// </summary>
        private string shortAnswer;

        /// <summary>
        /// The longAnswer value.
        /// </summary>
        private string longAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Answer"/> class.
        /// </summary>
        public Answer()
        {
        }

        /// <summary>
        /// Gets or sets the ShortAnswer.
        /// </summary>
        /// <value>The ShortAnswer value.</value>
        [XmlAttribute("SHRT")]
        public string ShortAnswer
        {
            get { return this.shortAnswer; }
            set { this.shortAnswer = value; }
        }

        /// <summary>
        /// Gets or sets the LongAnswer.
        /// </summary>
        /// <value>The LongAnswer value.</value>
        [XmlAttribute("LNG")]
        public string LongAnswer
        {
            get { return this.longAnswer; }
            set { this.longAnswer = value; }
        }
    }
}