using System;
using System.Collections.Generic;
using System.Text;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class PageNavigator
    {
        public void NavigateTo(Type pageType, params object[] args)
        {
            OnPageNavigate?.Invoke(this, new PageNavigateEventArgs(pageType, args));
        }
        public void NavigateTo<T>(params object[] args)
        {
            NavigateTo(typeof(T), args);
        }

        public event PageNavigateEventHandler OnPageNavigate;
    }

    public class PageNavigateEventArgs
    {
        public PageNavigateEventArgs(Type pageType, object[] args)
        {
            PageType = pageType;
            Args = args;
        }

        public Type PageType { get; }
        public object[] Args { get; }
    }

    public delegate void PageNavigateEventHandler(object sender, PageNavigateEventArgs args);

}
