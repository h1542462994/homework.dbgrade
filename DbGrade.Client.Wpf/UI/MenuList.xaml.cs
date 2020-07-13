using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tro.DbGrade.Client.Wpf.Models;
using Tro.DbGrade.Client.Wpf.Storage;

namespace Tro.DbGrade.Client.Wpf.UI
{
    /// <summary>
    /// MenuList.xaml 的交互逻辑
    /// </summary>
    public partial class MenuList : UserControl
    {
        public MenuList()
        {
            InitializeComponent();
            
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            OnPageNavigate();
        }

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectIndexProperty); }
            set { SetValue(SelectIndexProperty, value); }
        }

        public ObservableCollection<StringPage> StringPages
        {
            get { return (ObservableCollection<StringPage>)GetValue(StringPagesProperty); }
            set { SetValue(StringPagesProperty, value); }
        }

        public Frame Frame
        {

            get { return (Frame)GetValue(FrameProperty); }
            set { SetValue(FrameProperty, value); }
        }

        public event PageNavigateEventHandler PageNavigate;
        private void OnPageNavigate()
        {
            if(Frame != null)
            {
                Frame.NavigateTo(StringPages[SelectedIndex].PageType);
                PageNavigate?.Invoke(this, new PageNavigateEventArgs(StringPages[SelectedIndex].PageType, null));
            }
        }

        public static readonly DependencyProperty FrameProperty =
            DependencyProperty.Register(nameof(Frame), typeof(Frame), typeof(MenuList), new PropertyMetadata(null, SelectIndexPropertyChanged));

        public static readonly DependencyProperty StringPagesProperty =
            DependencyProperty.Register(nameof(StringPages), typeof(ObservableCollection<StringPage>), typeof(MenuList), new PropertyMetadata(new ObservableCollection<StringPage>(), SelectIndexPropertyChanged));

        public static readonly DependencyProperty SelectIndexProperty =
            DependencyProperty.Register(nameof(SelectedIndex), typeof(int), typeof(MenuList), new PropertyMetadata(0, SelectIndexPropertyChanged));

        private static void SelectIndexPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue != e.OldValue)
            {
                ((MenuList)d).OnPageNavigate();
            }
        }
    }
}
