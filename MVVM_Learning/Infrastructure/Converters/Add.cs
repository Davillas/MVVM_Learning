using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Markup;

namespace MVVM_Learning.Infrastructure.Converters
{
    internal class Add : BaseConverter
    {
        [ConstructorArgument("B")]
        public double B { get; set; } = 1;

        public Add()
        {

        }

        public Add(double K) => this.B = B;
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            var x = System.Convert.ToDouble(value, culture);

            return x + B;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            var x = System.Convert.ToDouble(value, culture);

            return x - B;
        }
    }
}
