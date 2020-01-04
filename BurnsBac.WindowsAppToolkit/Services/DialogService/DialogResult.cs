using System;
using System.Collections.Generic;
using System.Text;

namespace BurnsBac.WindowsAppToolkit.Services.DialogService
{
    /// <summary>
    /// Used to return information from a dialog window.
    /// </summary>
    public class DialogResult
    {
        /// <summary>
        /// Gets or sets which button was chosen, if any, to close the window.
        /// </summary>
        public WinformsDialogResult ResultOption { get; set; }

        /// <summary>
        /// Gets or sets additional data to return.
        /// </summary>
        public object ResultValue { get; set; }

        /// <summary>
        /// Gets or sets the type of additional data being returned.
        /// </summary>
        public Type ResultType { get; set; }
    }
}
