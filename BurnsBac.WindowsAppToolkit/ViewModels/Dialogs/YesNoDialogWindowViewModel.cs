using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BurnsBac.WindowsAppToolkit.Mvvm;
using BurnsBac.WindowsAppToolkit.Services.DialogService;
using BurnsBac.WindowsAppToolkit.Windows;

namespace BurnsBac.WindowsAppToolkit.ViewModels.Dialogs
{
    /// <summary>
    /// Dialog with "yes" and "no" buttons.
    /// </summary>
    public class YesNoDialogWindowViewModel : DialogWindowViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YesNoDialogWindowViewModel"/> class.
        /// </summary>
        public YesNoDialogWindowViewModel()
            : base()
        {
            NoCommand = new RelayCommand<ICloseable>(CloseWithNo);
            YesCommand = new RelayCommand<ICloseable>(CloseWithYes);
        }

        /// <summary>
        /// Gets or sets no button command.
        /// </summary>
        public ICommand NoCommand { get; set; }

        /// <summary>
        /// Gets or sets yes button command.
        /// </summary>
        public ICommand YesCommand { get; set; }

        /// <summary>
        /// No button command.
        /// </summary>
        /// <param name="c">Window to close (this).</param>
        private void CloseWithNo(ICloseable c)
        {
            UserDialogResult.ResultOption = WinformsDialogResult.No;
            c.Close();
        }

        /// <summary>
        /// Yes button command.
        /// </summary>
        /// <param name="c">Window to close (this).</param>
        private void CloseWithYes(ICloseable c)
        {
            UserDialogResult.ResultOption = WinformsDialogResult.Yes;
            c.Close();
        }
    }
}
