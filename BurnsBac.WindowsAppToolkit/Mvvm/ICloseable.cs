using System;
using System.Collections.Generic;
using System.Text;

namespace BurnsBac.WindowsAppToolkit.Mvvm
{
    /// <summary>
    /// Specifies object (window) has close method.
    /// </summary>
    public interface ICloseable
    {
        /// <summary>
        /// Closes object (window).
        /// </summary>
        void Close();
    }
}
