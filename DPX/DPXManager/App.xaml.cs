// <copyright file="App.xaml.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
using System.Windows;

namespace DPXManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Create an instance of the controller right away.
        /// </summary>
        private Controller c = Controller.Instance();
    }
}