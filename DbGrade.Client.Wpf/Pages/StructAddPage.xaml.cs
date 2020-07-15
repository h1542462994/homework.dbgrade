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
    /// StructAddPage.xaml 的交互逻辑
    /// </summary>
    public partial class StructAddPage : Page
    {
        public StructAddPage()
        {
            InitializeComponent();
            Loaded += StructAddPage_Loaded;
        }

        public StructAddPage(FrameWork.Dto.Profession profession): this()
        {
            TextBoxProfession.Text = profession.Name;
        }

        private void StructAddPage_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonCommit.Click += ButtonCommit_Click;
            State.AddMessage = "";
        }

        private async void ButtonCommit_Click(object sender, RoutedEventArgs e)
        {
            ButtonCommit.IsEnabled = false;
            var profession = TextBoxProfession.Text;
            var xclass = TextBoxClass.Text;
            var yearStr = TextBoxYear.Text;
            if (string.IsNullOrEmpty(profession) || string.IsNullOrEmpty(xclass) || string.IsNullOrEmpty(yearStr))
            {
                State.AddMessage = "参数不能为空";
                ButtonCommit.IsEnabled = true;
                return;
            }
            if (profession.Length > 20 || profession.Length > 20)
            {
                State.AddMessage = "参数太长";
                ButtonCommit.IsEnabled = true;
                return;
            }
            if (int.TryParse(yearStr, out int year))
            {
                await HttpClient.AddStruct(profession, xclass, year);

                ButtonCommit.IsEnabled = true;
                await Task.Delay(3000);
                PageNavigator.PopupClose();
            } else
            {
                State.AddMessage = "输入不符合数字";
                ButtonCommit.IsEnabled = true;
                return;
            }
        }

        public PageNavigator PageNavigator => App.Current.ServiceProvider.GetService<PageNavigator>();
        public GradeHttpClient HttpClient => App.Current.ServiceProvider.GetService<GradeHttpClient>();
        public GlobalState State => App.Current.ServiceProvider.GetService<GlobalState>();
    }
}
