using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Tro.DbGrade.Client.Wpf.Converts
{
    [ValueConversion(typeof(int), typeof(string))]
    class IntStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return "";
            }
            int v = int.Parse(value.ToString());
            if (v <= 0)
            {
                return "--全部--";
            } else
            {
                return v.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
