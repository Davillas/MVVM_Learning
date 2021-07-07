using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace MVVM_Learning.Infrastructure.Converters
{

    /// <summary>
    /// Linear Conversion f(x) = k*x + b
    /// </summary>
    [ValueConversion(typeof(double), typeof(double))]
    [MarkupExtensionReturnType(typeof(Linear))]
    internal class Linear : BaseConverter
    {
        [ConstructorArgument("K")]
        public double K { get; set; } = 1;
        [ConstructorArgument("B")]
        public double B { get; set; }

        public Linear()
        { }
        public Linear(double K) => this.K = K;

        public Linear(double K, double B) : this(K) => this.B = B;

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            var x = System.Convert.ToDouble(value, culture);
            return K * x + B;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            var y = System.Convert.ToDouble(value, culture);
            return (y - B) / K;
        }
    }
}
