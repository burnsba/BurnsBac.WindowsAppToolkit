using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BurnsBac.WindowsAppToolkit.Dto;
using BurnsBac.WindowsAppToolkit.HotConfig;

namespace BurnsBac.WindowsAppToolkit.ViewModels
{
    /// <summary>
    /// View model for skin config textbox setting.
    /// </summary>
    public class ConfigSettingTextboxViewModel : ConfigSettingBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigSettingTextboxViewModel"/> class.
        /// </summary>
        /// <param name="item">Source item.</param>
        public ConfigSettingTextboxViewModel(Setting item)
            : base(item)
        {
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            // nothing to do.
        }
    }
}
