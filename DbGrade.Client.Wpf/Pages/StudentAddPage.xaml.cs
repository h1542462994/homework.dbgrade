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
using Tro.DbGrade.FrameWork.Models.Types;

namespace Tro.DbGrade.Client.Wpf.Pages
{
    /// <summary>
    /// StudentAddPage.xaml 的交互逻辑
    /// </summary>
    public partial class StudentAddPage : Page
    {
        public StudentAddPage()
        {
            InitializeComponent();
            Loaded += StudentAddPage_Loaded;
        }

        private void StudentAddPage_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonCommit.Click += ButtonCommit_Click;
            State.AddMessage = "";
        }

        private async void ButtonCommit_Click(object sender, RoutedEventArgs e)
        {
            ButtonCommit.IsEnabled = false;
            var sno = TextBoxSno.Text;
            var name = TextBoxName.Text;
            var ageStr = TextBoxAge.Text;
            Sex sex = (Sex)ComboBoxSex.SelectedIndex;
            if (string.IsNullOrEmpty(sno) || string.IsNullOrEmpty(ageStr) || string.IsNullOrEmpty(name))
            {
                State.AddMessage = "参数不能为空";
                ButtonCommit.IsEnabled = true;
                return;
            }
            if (sno.Length > 20)
            {
                State.AddMessage = "参数太长";
                ButtonCommit.IsEnabled = true;
                return;
            }
            if (int.TryParse(ageStr, out int age))
            {
                if (age < 8 || age > 120)
                {
                    State.AddMessage = "年龄不是一个学生该有的年龄";
                }

                if (SelectorViewModel.CityIndex <= 0 || SelectorViewModel.ClassIndex <= 0)
                {
                    State.AddMessage = "城市或者班级必选";
                    ButtonCommit.IsEnabled = true;
                    return;
                }

                var response = await HttpClient.AddStudent(sno, name, sex, age,
                    SelectorViewModel.Xclasses[SelectorViewModel.ClassIndex].Cno,
                    SelectorViewModel.Cities[SelectorViewModel.CityIndex].Cino);
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

            }
            else
            {
                State.AddMessage = "输入不符合数字";
                ButtonCommit.IsEnabled = true;
                return;
            }
        }

        public SelectorViewModel SelectorViewModel => App.Current.ServiceProvider.GetService<SelectorViewModel>();
        public PageNavigator PageNavigator => App.Current.ServiceProvider.GetService<PageNavigator>();
        public GradeHttpClient HttpClient => App.Current.ServiceProvider.GetService<GradeHttpClient>();
        public GlobalState State => App.Current.ServiceProvider.GetService<GlobalState>();
    }
}
