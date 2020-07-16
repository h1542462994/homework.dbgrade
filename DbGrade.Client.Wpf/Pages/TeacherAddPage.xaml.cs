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
    /// TeacherAddPage.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherAddPage : Page
    {
        public TeacherAddPage()
        {
            InitializeComponent();
        }

        public PageNavigator PageNavigator => App.Current.ServiceProvider.GetService<PageNavigator>();
        public GradeHttpClient HttpClient => App.Current.ServiceProvider.GetService<GradeHttpClient>();
        public GlobalState State => App.Current.ServiceProvider.GetService<GlobalState>();
    }
}
