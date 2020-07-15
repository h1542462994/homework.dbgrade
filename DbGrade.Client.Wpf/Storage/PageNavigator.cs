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

        public void NavigateToPopup(Type pageType, params object[] args)
        {
            OnPopupPageNavigate?.Invoke(this, new PageNavigateEventArgs(pageType, args));
        }

        public void NavigateToPopup<T>(params object[] args)
        {
            NavigateToPopup(typeof(T), args);
        }

        public void PopupClose()
        {
            OnPopupClose?.Invoke(this, new EventArgs());
        }

        public event PageNavigateEventHandler OnPageNavigate;
        public event PageNavigateEventHandler OnPopupPageNavigate;
        public event EventHandler OnPopupClose;
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
