using System;
using System.Collections.Generic;
using System.Text;
using BurnsBac.WindowsAppToolkit.ViewModels;
using BurnsBac.WindowsAppToolkit.ViewModels.Dialogs;

namespace BurnsBac.WindowsAppToolkit.Services.DialogService
{
    /// <summary>
    /// Used to manage creating dialog windows.
    /// </summary>
    public static class DialogService
    {
        /// <summary>
        /// Creates a new dialog with "yes" and "no" buttons.
        /// </summary>
        /// <param name="windowTitle">Title of window.</param>
        /// <param name="message">Message to show in window.</param>
        /// <returns>Result.</returns>
        public static DialogResult OpenYesNoDialog(string windowTitle, string message)
        {
            return DialogCommon(new YesNoDialogWindowViewModel(), windowTitle, message);
        }

        /// <summary>
        /// Creates a new dialog with "ok" and "cancel" buttons.
        /// </summary>
        /// <param name="windowTitle">Title of window.</param>
        /// <param name="message">Message to show in window.</param>
        /// <returns>Result.</returns>
        public static DialogResult OpenOkCancelDialog(string windowTitle, string message)
        {
            return DialogCommon(new OkCancelDialogWindowViewModel(), windowTitle, message);
        }

        /// <summary>
        /// Creates a new dialog with "ok" and "cancel" buttons. The user can also
        /// enter text in a textbox.
        /// </summary>
        /// <param name="windowTitle">Title of window.</param>
        /// <param name="message">Message to show in window.</param>
        /// <returns>Result.</returns>
        public static DialogResult OpenOkCancelStringDialog(string windowTitle, string message)
        {
            return DialogCommon(new OkCancelStringDialogWindowViewModel(), windowTitle, message);
        }

        /// <summary>
        /// Helper function for common code. Creates the window and returns result.
        /// </summary>
        /// <param name="vm">View model.</param>
        /// <param name="windowTitle">Title of window.</param>
        /// <param name="message">Message to show in window.</param>
        /// <returns>Result.</returns>
        private static DialogResult DialogCommon(DialogWindowViewModelBase vm, string windowTitle, string message)
        {
            vm.WindowTitle = windowTitle;
            vm.BodyMessage = message;

            var d = new Windows.DialogWindow(vm);
            d.ShowDialog();
            return vm.UserDialogResult;
        }
    }
}
