using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Tro.DbGrade.Client.Wpf.Models;
using System.Collections.ObjectModel;
using Tro.DbGrade.Client.Wpf.Pages;
using Tro.DbGrade.Client.Wpf.Storage;

namespace Tro.DbGrade.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PageNavigator.OnPageNavigate += (o, e) =>
            {
                ContentFrame.NavigateTo(e.PageType);
            };
        }

        public PageNavigator PageNavigator => App.Current.ServiceProvider.GetService<PageNavigator>();

        public ObservableCollection<StringPage> StringPages
        {
            get { return (ObservableCollection<StringPage>)GetValue(StringPagesProperty); }
            set { SetValue(StringPagesProperty, value); }
        }

        public static readonly DependencyProperty StringPagesProperty =
            DependencyProperty.Register("StringPages", typeof(ObservableCollection<StringPage>), typeof(MainWindow), new PropertyMetadata(
                new ObservableCollection<StringPage>
                {
                    new StringPage("学生详情", typeof(StudentPage)),
                    new StringPage("教师详情", typeof(TeacherPage))
                }
                ));




    }
}
