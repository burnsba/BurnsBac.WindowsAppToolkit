using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace BurnsBac.WindowsAppToolkit.Converters
{
    /// <summary>
    /// Converts bool to visibility status.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(System.Windows.Visibility))]
    public class BoolToVisbilityConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts bool to visibility status.
        /// </summary>
        /// <param name="value">Value to convert (bool).</param>
        /// <param name="targetType">Type to convert to (Visibility).</param>
        /// <param name="parameter">Convert parameter.</param>
        /// <param name="culture">Convert culture.</param>
        /// <returns>
        /// Visibility status.
        /// </returns>
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(System.Windows.Visibility))
            {
                throw new InvalidOperationException("The target must be a System.Windows.Visibility");
            }

            return (bool)value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// NotSupported.
        /// </summary>
        /// <param name="value">Value to convert (Visibility).</param>
        /// <param name="targetType">Type to convert to (bool).</param>
        /// <param name="parameter">Convert parameter.</param>
        /// <param name="culture">Convert culture.</param>
        /// <returns>
        /// bool.
        /// </returns>
        /// <remarks>
        /// Converts visibility to bool status.
        /// </remarks>
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
