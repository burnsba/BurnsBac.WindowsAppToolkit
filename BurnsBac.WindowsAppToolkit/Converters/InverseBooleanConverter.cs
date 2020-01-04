using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace BurnsBac.WindowsAppToolkit.Converters
{
    /// <summary>
    /// Inverts a bool.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts bool to inverted value.
        /// </summary>
        /// <param name="value">Value to convert (bool).</param>
        /// <param name="targetType">Type to convert to (bool).</param>
        /// <param name="parameter">Convert parameter.</param>
        /// <param name="culture">Convert culture.</param>
        /// <returns>
        /// Inverted value.
        /// </returns>
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
            {
                throw new InvalidOperationException("The target must be a boolean");
            }

            return !(bool)value;
        }

        /// <summary>
        /// NotSupported. Same as Convert.
        /// </summary>
        /// <param name="value">Value to convert (bool).</param>
        /// <param name="targetType">Type to convert to (bool).</param>
        /// <param name="parameter">Convert parameter.</param>
        /// <param name="culture">Convert culture.</param>
        /// <returns>
        /// Inverted value.
        /// </returns>
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
