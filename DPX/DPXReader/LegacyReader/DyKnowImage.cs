// <copyright file="DyKnowImage.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>A representation of an image embedded in a DyKnow panel.</summary>
namespace DPXReader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A representation of an image embedded in a DyKnow panel.
    /// </summary>
    public class DyKnowImage
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
        /// The unique id.
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
        /// Initializes a new instance of the <see cref="DyKnowImage"/> class.
        /// </summary>
        /// <param name="ut">The ut value.</param>
        /// <param name="sp">The sp value.</param>
        /// <param name="pageWidth">The pageWidth value.</param>
        /// <param name="pageHeight">The pageHeight value.</param>
        /// <param name="uid">The uid value.</param>
        /// <param name="id">The unique id.</param>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        public DyKnowImage(int ut, string sp, int pageWidth, int pageHeight, string uid, string id, int width, int height)
        {
            this.ut = ut;
            this.sp = sp;
            this.pageWidth = pageWidth;
            this.pageHeight = pageHeight;
            this.uid = new Guid(uid);
            this.id = new Guid(id);
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DyKnowImage"/> class.
        /// </summary>
        /// <param name="ut">The ut value.</param>
        /// <param name="sp">The sp value.</param>
        /// <param name="pageWidth">The pageWidth value.</param>
        /// <param name="pageHeight">The pageHeight value.</param>
        /// <param name="uid">The uid value.</param>
        /// <param name="id">The unique id.</param>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        public DyKnowImage(int ut, string sp, int pageWidth, int pageHeight, Guid uid, Guid id, int width, int height)
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
        /// Gets the id.
        /// </summary>
        /// <value>The unique id.</value>
        internal Guid Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the pageWidth.
        /// </summary>
        /// <value>The pageWidth value.</value>
        internal int PageWidth
        {
            get { return this.pageWidth; }
        }

        /// <summary>
        /// Gets the pageHeight.
        /// </summary>
        /// <value>The pageHeight value.</value>
        internal int PageHeight
        {
            get { return this.pageHeight; }
        }

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        /// <value>The width of the image.</value>
        internal double ImageWidth
        {
            get { return (double)this.width / ReferenceWidth; }
        }

        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        /// <value>The height of the image.</value>
        internal double ImageHeight
        {
            get { return (double)this.height / ReferenceHeight; }
        }

        /// <summary>
        /// Gets the left position for the image.
        /// </summary>
        /// <value>The left position.</value>
        internal double PositionLeft
        {
            get
            {
                int start = 0;
                int end = this.sp.IndexOf(':');
                string val = this.sp.Substring(start, end);
                double num = int.Parse(val);
                return num / DyKnowImage.ReferenceWidth;
            }
        }

        /// <summary>
        /// Gets the top position for the image.
        /// </summary>
        /// <value>The top position.</value>
        internal double PositionTop
        {
            get
            {
                int start = this.sp.IndexOf(':') + 1;
                string val = this.sp.Substring(start);
                double num = int.Parse(val);
                return num / ReferenceHeight;
            }
        }

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ut.ToString() + " - " + this.sp.ToString() + " - " + this.uid.ToString();
        }
    }
}