using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Tro.DbGrade.Client.Wpf.Converts
{
    [ValueConversion(typeof(int), typeof(Visibility))]
    public class IntJudgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int v = (int)value;
            int p = int.Parse(parameter.ToString());
            if (v == p)
            {
                return Visibility.Visible;
            } 
            else
            {
                return Visibility.Collapsed;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
