using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.Client.Wpf.Converts
{
    [ValueConversion(typeof(Term), typeof(string))]
    public class TermStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Term v = (Term)value;
            if (v == Term.First)
            {
                return "上学期";
            } 
            else
            {
                return "下学期";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
