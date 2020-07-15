using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Tro.DbGrade.Client.Wpf
{
    public static class UIExtensions
    {
        public static void NavigateTo(this Frame frame, Type pageType, params object[] args)
        {
            dynamic page = Activator.CreateInstance(pageType, args);
            frame.Navigate(page);
        }

        public static void NavigateTo<T>(this Frame frame, params object[] args)
        {
            NavigateTo(frame, typeof(T), args);
        }
    }
}
