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
    /// Dialog with "ok" and "cancel" buttons.
    /// </summary>
    public class OkCancelDialogWindowViewModel : DialogWindowViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OkCancelDialogWindowViewModel"/> class.
        /// </summary>
        public OkCancelDialogWindowViewModel()
            : base()
        {
            OkCommand = new RelayCommand<ICloseable>(CloseWithOk);
            CancelCommand = new RelayCommand<ICloseable>(CloseWithCancel);
        }

        /// <summary>
        /// Gets or sets cancel button command.
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Gets or sets ok button command.
        /// </summary>
        public ICommand OkCommand { get; set; }

        /// <summary>
        /// Cancel button command.
        /// </summary>
        /// <param name="c">Window to close (this).</param>
        private void CloseWithCancel(ICloseable c)
        {
            UserDialogResult.ResultOption = WinformsDialogResult.Cancel;
            c.Close();
        }

        /// <summary>
        /// Ok button command.
        /// </summary>
        /// <param name="c">Window to close (this).</param>
        private void CloseWithOk(ICloseable c)
        {
            UserDialogResult.ResultOption = WinformsDialogResult.OK;
            c.Close();
        }
    }
}
