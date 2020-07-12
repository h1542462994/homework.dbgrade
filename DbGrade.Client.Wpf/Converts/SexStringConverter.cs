using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.Client.Wpf.Converts
{
    [ValueConversion(typeof(Sex), typeof(string))]
    public class SexStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (Sex)value;
            if (v == Sex.Male)
            {
                return "男";
            } else
            {
                return "女";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (string)value;
            if (v == "男")
            {
                return Sex.Male;
            } else
            {
                return Sex.Female;
            }
        }
    }
}
