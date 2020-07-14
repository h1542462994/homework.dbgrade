using System;
using System.Collections.Generic;
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
using Tro.DbGrade.Client.Wpf.Storage;

namespace Tro.DbGrade.Client.Wpf.Pages
{
    /// <summary>
    /// StudentPage.xaml 的交互逻辑
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            Loaded += StudentPage_Loaded;
        }



        private void StudentPage_Loaded(object sender, RoutedEventArgs e)
        {
            //DataGrid1.ItemsSource = RemoteStorage.StudentOutView;
            //RemoteStorage.FetchStudent();
            SelectorViewModel.SelectorMode = SelectorMode.StructDest;
            ButtonQuery.Click += (o, e) => { RemoteStorage.FetchStudents(); };
           
        }

        public GlobalState State => App.Current.ServiceProvider.GetService<GlobalState>();
        public RemoteStorage RemoteStorage => App.Current.ServiceProvider.GetService<RemoteStorage>();
        public PageNavigator PageNavigator => App.Current.ServiceProvider.GetService<PageNavigator>();
        public SelectorViewModel SelectorViewModel => App.Current.ServiceProvider.GetService<SelectorViewModel>();

        private void DataGridLink_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBlock = (TextBlock)sender;
            string sno = textBlock.Tag as string;
            State.Sno = sno;
            PageNavigator.NavigateTo<StudentDetailPage>();
            e.Handled = true;
        }
    }
}
