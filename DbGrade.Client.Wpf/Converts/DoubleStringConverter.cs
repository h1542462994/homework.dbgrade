using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Tro.DbGrade.Client.Wpf.Converts
{
    [ValueConversion(typeof(double), typeof(string))]
    public class DoubleStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double v = (double)value;
            return Math.Round(v, 2).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse(value.ToString());
        }
    }
}
