using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;

namespace BurnsBac.WindowsAppToolkit.Mvvm
{
    /// <summary>
    /// Base class for window ViewModel.
    /// </summary>
    public abstract class WindowViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="window">Window to close.</param>
        protected void CloseWindow(ICloseable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
