﻿// <copyright file="AddNewDate.xaml.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The window that allows a new date to be added to the database.</summary>
namespace DPXManager
{
    using System;
    using System.Windows;

    /// <summary>
    /// The window that allows a new date to be added to the database.
    /// </summary>
    public partial class AddNewDate : Window
    {
        /// <summary>
        /// An instance of the controller.
        /// </summary>
        private Controller c = Controller.Instance();

        /// <summary>
        /// Initializes a new instance of the AddNewDate class.
        /// </summary>
        public AddNewDate()
        {
            InitializeComponent();

            if (this.c.DB.IsClassdate(dateTimePicker.Value.Date))
            {
                buttonAddDate.IsEnabled = false;
            }
            else
            {
                buttonAddDate.IsEnabled = true;
            }
        }

        /// <summary>
        /// The selected date changed and the add button will toggle depending on if it is a valid date.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.c.DB.IsClassdate(dateTimePicker.Value.Date))
            {
                buttonAddDate.IsEnabled = false;
            }
            else
            {
                buttonAddDate.IsEnabled = true;
            }
        }

        /// <summary>
        /// Add the selected date to the list of dates.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ButtonAddDate_Click(object sender, RoutedEventArgs e)
        {
            this.c.DB.AddClassdate(dateTimePicker.Value.Date);
            this.c.RefreshClassdate();
            this.Close();
        }
    }
}