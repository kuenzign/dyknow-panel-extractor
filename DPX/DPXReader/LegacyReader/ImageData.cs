﻿// <copyright file="ImageData.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>A representation of an image stored in the DyKnow XML file.</summary>
namespace DPXReader
{
    using System;

    /// <summary>
    /// A representation of an image stored in the DyKnow XML file.
    /// </summary>
    public class ImageData
    {
        /// <summary>
        /// The id value.
        /// </summary>
        private Guid id;

        /// <summary>
        /// The img pages.
        /// </summary>
        private string img;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageData"/> class.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="img">The img pages.</param>
        public ImageData(Guid id, string img)
        {
            this.id = id;
            this.img = img;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageData"/> class.
        /// </summary>
        /// <param name="id">The id value.</param>
        /// <param name="img">The img pages.</param>
        public ImageData(string id, string img)
        {
            this.id = new Guid(id);
            this.img = img;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id value.</value>
        public Guid Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets the img.
        /// </summary>
        /// <value>The img pages.</value>
        public string Img
        {
            get { return this.img; }
        }

        /// <summary>
        /// Gets the image pages string64.
        /// </summary>
        /// <returns>A string64 representation of the image.</returns>
        public string GetImageDataString64() => this.img;

        /// <summary>
        /// Returns a <see cref="string"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString() => this.id.ToString() + " - Length: " + this.img.Length;
    }
}