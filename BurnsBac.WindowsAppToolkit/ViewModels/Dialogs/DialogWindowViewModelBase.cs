using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using BurnsBac.WindowsAppToolkit.Services.DialogService;

namespace BurnsBac.WindowsAppToolkit.ViewModels.Dialogs
{
    /// <summary>
    /// Base class for creating dialog windows.
    /// </summary>
    public abstract class DialogWindowViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogWindowViewModelBase"/> class.
        /// </summary>
        public DialogWindowViewModelBase()
        {
            UserDialogResult = new DialogResult();
            UserDialogResult.ResultOption = WinformsDialogResult.None;

            WindowTitle = "Dialog";
            BodyMessage = "Message";
        }

        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        public string WindowTitle { get; set; }

        /// <summary>
        /// Gets or sets the message to show in the dialog.
        /// </summary>
        public string BodyMessage { get; set; }

        /// <summary>
        /// Gets or sets result data to return when dialog is closed.
        /// </summary>
        public DialogResult UserDialogResult { get; set; }
    }
}
