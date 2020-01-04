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
    /// Dialog with "ok" and "cancel" buttons. The user can also
    /// enter text in a textbox.
    /// </summary>
    public sealed class OkCancelStringDialogWindowViewModel : OkCancelDialogWindowViewModel
    {
        private string _userInput;

        /// <summary>
        /// Gets or sets text that user entered.
        /// </summary>
        public string UserInput
        {
            get
            {
                return _userInput;
            }

            set
            {
                _userInput = value;
                UserDialogResult.ResultValue = _userInput;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OkCancelStringDialogWindowViewModel"/> class.
        /// </summary>
        public OkCancelStringDialogWindowViewModel()
            : base()
        {
            UserDialogResult.ResultType = typeof(string);
        }
    }
}
