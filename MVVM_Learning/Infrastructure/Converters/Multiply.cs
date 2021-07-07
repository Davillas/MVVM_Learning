using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace MVVM_Learning.Infrastructure.Converters
{
    internal class Multiply : BaseConverter
    {
        [ConstructorArgument("K")]
        public double K { get; set; } = 1;

        public Multiply()
        {
            
        }

        public Multiply(double K) => this.K = K;
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            var x = System.Convert.ToDouble(value, culture);

            return x * K;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            var x = System.Convert.ToDouble(value, culture);

            return x / K;
        }
    }
}
