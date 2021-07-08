using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace MVVM_Learning.Infrastructure.Converters
{
    internal class ParametricRatioConverter : Freezable, IValueConverter
    {
        #region Value : double - Added Value

        /// <summary>$summary$</summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(ParametricRatioConverter),
                new PropertyMetadata(1.0));

        /// <summary>$summary$</summary>
        //[Category("")]
        [Description("Added Value")]
        public double Value
        {
            get => (double) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var target_value = System.Convert.ToDouble(value, culture);

            return target_value * Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var target_value = System.Convert.ToDouble(value, culture);

            return target_value / Value;
        }

        protected override Freezable CreateInstanceCore() => new ParametricRatioConverter {Value = Value};
    }
}
