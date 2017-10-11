// <copyright file="App.xaml.cs" company="University of Louisville Speed School of Engineering">
// GNU General Public License v3
// </copyright>
// <summary>The main application for DPX.</summary>
namespace DPXManager
{
    using System.Windows;

    /// <summary>
    /// The main application for DPX.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Create an instance of the controller right away.
        /// </summary>
        private Controller c = Controller.Instance();
    }
}