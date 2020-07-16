using System;
using System.Collections.Generic;
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
using Tro.DbGrade.Client.Wpf.Storage;

namespace Tro.DbGrade.Client.Wpf.Pages
{
    /// <summary>
    /// ReportAddPage.xaml 的交互逻辑
    /// </summary>
    public partial class ReportAddPage : Page
    {
        public ReportAddPage()
        {
            InitializeComponent();
            Loaded += ReportAddPage_Loaded;
        }

        private void ReportAddPage_Loaded(object sender, RoutedEventArgs e)
        {
            State.AddMessage = "";
            ButtonCommit.Click += ButtonCommit_Click;
        }

        private async void ButtonCommit_Click(object sender, RoutedEventArgs e)
        {
            ButtonCommit.IsEnabled = false;
            var gradeStr = TextBoxGrade.Text;
            if (string.IsNullOrEmpty(gradeStr))
            {
                State.AddMessage = "参数不能为空";
                ButtonCommit.IsEnabled = true;
                return;
            }
            if (SelectorViewModel.StudentIndex <= 0 || SelectorViewModel.CourseIndex <= 0)
            {
                State.AddMessage = "学生或者课程必选";
                ButtonCommit.IsEnabled = true;
                return;
            }
            if (double.TryParse(gradeStr, out double grade))
            {
                if (grade < 0 || grade > 100)
                {
                    State.AddMessage = "成绩必须在0-100之间";
                    ButtonCommit.IsEnabled = true;
                    return;
                }

                var response = await HttpClient.AddReportAsync(
                    SelectorViewModel.Students[SelectorViewModel.StudentIndex].Sno,
                    SelectorViewModel.Courses[SelectorViewModel.CourseIndex].Cono,
                    grade
                    );
                if (response.Code == System.Net.HttpStatusCode.OK)
                {
                    State.AddMessage = "添加成功";
                    ButtonCommit.IsEnabled = true;
                    await Task.Delay(3000);
                    PageNavigator.PopupClose();
                } else
                {
                    State.AddMessage = response.Msg;
                    ButtonCommit.IsEnabled = true;
                }
            } else
            {
                State.AddMessage = "输入不符合数字";
                ButtonCommit.IsEnabled = true;
                return;
            }

            ButtonCommit.IsEnabled = true;
        }

        public SelectorViewModel SelectorViewModel => App.Current.ServiceProvider.GetService<SelectorViewModel>();

        public PageNavigator PageNavigator => App.Current.ServiceProvider.GetService<PageNavigator>();
        public GradeHttpClient HttpClient => App.Current.ServiceProvider.GetService<GradeHttpClient>();
        public GlobalState State => App.Current.ServiceProvider.GetService<GlobalState>();
    }


}
