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
                ContentFrame.NavigateTo(e.PageType, e.Args);
            };
            PageNavigator.OnPopupPageNavigate += (o, e) =>
            {
                FramePopup.NavigateTo(e.PageType, e.Args);
                GridPopup.Visibility = Visibility.Visible;
            };
            PageNavigator.OnPopupClose += (o, e) => GridPopup.Visibility = Visibility.Hidden;
            GridPopup.MouseUp += (o, e) => GridPopup.Visibility = Visibility.Hidden;
            //在Frame中监听MouseUp，防止事件向上冒泡。
            FramePopup.MouseUp += (o, e) => e.Handled = true;
            
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
                    new StringPage("地区概览信息", typeof(DestPage)),
                    new StringPage("班级概览信息", typeof(StructPage)),
                    new StringPage("学生基本信息", typeof(StudentPage)),
                    new StringPage("教师基本信息", typeof(TeacherPage)),
                    new StringPage("成绩详细查询", typeof(ReportsPage)),
                    new StringPage("成绩统计查询", typeof(ReportSummaryPage)),
                    new StringPage("课程查询", typeof(CoursePage)),
                    new StringPage("开课详细查询", typeof(OpenCoursePage)),
                    new StringPage("学期查询", typeof(TermPage))
                }));
    }
}
