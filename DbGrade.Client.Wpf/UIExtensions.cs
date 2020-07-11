using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Tro.DbGrade.Client.Wpf
{
    public static class UIExtensions
    {
        public static void NavigateTo(this Frame frame, Type pageType)
        {
            dynamic page = Activator.CreateInstance(pageType);
            frame.Navigate(page);
        }

        public static void NavigateTo<T>(this Frame frame)
        {
            NavigateTo(frame, typeof(T));
        }
    }
}
