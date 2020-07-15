using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    /// <summary>
    /// 全局状态
    /// </summary>
    public class GlobalState : DependencyObject
    {
        public string Sno
        {
            get { return (string)GetValue(SnoProperty); }
            set { SetValue(SnoProperty, value); }
        }
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public string AddMessage
        {
            get { return (string)GetValue(AddMessageProperty); }
            set { SetValue(AddMessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof(string), typeof(GlobalState), new PropertyMetadata(""));

        public static readonly DependencyProperty SnoProperty =
            DependencyProperty.Register("Sno", typeof(string), typeof(GlobalState), new PropertyMetadata(""));

        public static readonly DependencyProperty AddMessageProperty =
            DependencyProperty.Register("AddMessage", typeof(string), typeof(GlobalState), new PropertyMetadata(""));
    }
}
