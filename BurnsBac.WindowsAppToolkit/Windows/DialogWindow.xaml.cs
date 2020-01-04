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
using BurnsBac.WindowsAppToolkit.ViewModels.Dialogs;

namespace BurnsBac.WindowsAppToolkit.Windows
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml .
    /// </summary>
    public partial class DialogWindow : Window, ICloseable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogWindow"/> class.
        /// </summary>
        /// <param name="dataContext">ViewModel for window.</param>
        public DialogWindow(DialogWindowViewModelBase dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
