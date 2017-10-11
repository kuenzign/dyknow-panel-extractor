// <copyright file="DisplayPanelEventArgs.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The event arguments for displaying a panel.</summary>
namespace DPXAnswers
{
    using System;

    /// <summary>
    /// The event arguments for displaying a panel.
    /// </summary>
    public class DisplayPanelEventArgs : EventArgs
    {
        /// <summary>
        /// The index of the panel.
        /// </summary>
        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayPanelEventArgs"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        public DisplayPanelEventArgs(int index)
            : base()
        {
            this.index = index;
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>The index.</value>
        public int Index
        {
            get { return this.index; }
        }
    }
}