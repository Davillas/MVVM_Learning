using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MVVM_Learning.Infrastructure.Converters
{
    class DebugConverter : BaseConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Diagnostics.Debugger.Break();
            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
