using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Tro.DbGrade.Client.Wpf.Converts
{
    [ValueConversion(typeof(IEnumerable<FrameWork.Dto.Profession>), typeof(IEnumerable<FrameWork.Dto.Xclass>))]
    class ProfessionClassConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (IEnumerable<FrameWork.Dto.Profession>)value;
            int p = int.Parse(parameter.ToString());
            return v.ElementAt(p);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
