// <copyright file="DyKnowPenStroke.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>A representation of a single pen stroke.</summary>
namespace DPXReader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A representation of a single pen stroke.
    /// </summary>
    public class DyKnowPenStroke
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
        /// The pages value.
        /// </summary>
        private string data;

        /// <summary>
        /// The deleted value.
        /// </summary>
        private bool deleted;

        /// <summary>
        /// Initializes a new instance of the <see cref="DyKnowPenStroke"/> class.
        /// </summary>
        /// <param name="ut">The ut value.</param>
        /// <param name="pageWidth">The pageWidth value.</param>
        /// <param name="pageHeight">The pageHeight value.</param>
        /// <param name="uid">The uid value.</param>
        /// <param name="data">The pages value.</param>
        public DyKnowPenStroke(int ut, int pageWidth, int pageHeight, string uid, string data)
        {
            this.ut = ut;
            this.pageWidth = pageWidth;
            this.pageHeight = pageHeight;
            this.uid = uid;
            this.data = data;
            this.deleted = false;
        }

        /// <summary>
        /// Gets the UT.
        /// </summary>
        /// <value>The UT value.</value>
        public int UT
        {
            get { return this.ut; }
        }

        /// <summary>
        /// Gets the PageWidth.
        /// </summary>
        /// <value>The PageWidth value.</value>
        public int PageWidth
        {
            get { return this.pageWidth; }
        }

        /// <summary>
        /// Gets the PageHeight.
        /// </summary>
        /// <value>The PageHeight value.</value>
        public int PageHeight
        {
            get { return this.pageHeight; }
        }

        /// <summary>
        /// Gets the UID.
        /// </summary>
        /// <value>The UID value.</value>
        public string UID
        {
            get { return this.uid; }
        }

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>The Data value.</value>
        public string Data
        {
            get { return this.data; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="DyKnowPenStroke"/> is IsDeleted.
        /// </summary>
        /// <value><c>True</c> if IsDeleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted
        {
            get { return this.deleted; }
        }

        /// <summary>
        /// Deletes the stroke.
        /// </summary>
        public void DeleteStroke()
        {
            this.deleted = true;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "UT=" + this.ut.ToString() + " PW=" + this.pageWidth.ToString() + " UID=" + this.uid +
                " DATA=" + this.data + " DEL=" + this.deleted.ToString();
        }
    }
}