using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.Client.Wpf.Converts
{

    [ValueConversion(typeof(Level), typeof(string))]
    public class LevalStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Level v = (Level)value;
            if (v == Level.Lecture)
            {
                return "讲师";
            }
            else if (v == Level.Associate)
            {
                return "副教授";
            }
            else
            {
                return "教授";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
