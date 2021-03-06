﻿// <copyright file="PanelPreview.xaml.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The window that displays the preview for a DyKnow panel.</summary>
namespace DPXManager
{
    using DPXReader;
    using System.Windows;

    /// <summary>
    /// The window that displays the preview for a DyKnow panel.
    /// </summary>
    public partial class PanelPreview : Window
    {
        /// <summary>
        /// DyKnow reader instance which contains the information about the file.
        /// </summary>
        private DyKnowReader dr;

        /// <summary>
        /// Initializes a new instance of the PanelPreview class.
        /// </summary>
        /// <param name="dr">Already opened instance of the DyKnow reader class.</param>
        public PanelPreview(DyKnowReader dr)
        {
            InitializeComponent();
            this.dr = dr;
        }

        /// <summary>
        /// Display the panel specified by an index.
        /// </summary>
        /// <param name="n">The panel number to display.</param>
        public void DisplayPanel(int n)
        {
            // Some error checking to make sure we don't crash
            if (this.dr != null && n >= 0 && n < this.dr.NumOfPages())
            {
                this.dr.FillInkCanvas(Inky, n);
            }
        }
    }
}