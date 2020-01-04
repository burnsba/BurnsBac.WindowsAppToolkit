using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BurnsBac.WindowsAppToolkit.Mvvm;
using BurnsBac.WindowsAppToolkit.ViewModels;

namespace BurnsBac.WindowsAppToolkit.Windows
{
    /// <summary>
    /// Interaction logic for SkinConfigWindow.xaml .
    /// </summary>
    public partial class ConfigWindow : Window, ICloseable
    {
        private ConfigViewModel _vm = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigWindow"/> class.
        /// </summary>
        /// <param name="settingsFilename">Path to file containing settings for this.</param>
        public ConfigWindow(string settingsFilename)
        {
            InitializeComponent();

            _vm = new ConfigViewModel(settingsFilename);

            DataContext = _vm;
        }

        private void SkinConfigWindowx_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _vm.Dispose();
        }
    }
}
