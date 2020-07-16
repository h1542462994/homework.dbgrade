using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
    /// DestAddPage.xaml 的交互逻辑
    /// </summary>
    public partial class DestAddPage : Page
    {
        public DestAddPage()
        {
            InitializeComponent();
            Loaded += DestAddPage_Loaded;
        }

        public DestAddPage(FrameWork.Dto.Province province) : this()
        {
            TextBoxProvince.Text = province.Name;
        }

        private void DestAddPage_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonCommit.Click += ButtonCommit_Click;
            State.AddMessage = "";
        }

        private async void ButtonCommit_Click(object sender, RoutedEventArgs e)
        {
            ButtonCommit.IsEnabled = false;
            var province = TextBoxProvince.Text;
            var city = TextBoxCity.Text;
            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(city))
            {
                State.AddMessage = "参数不能为空";
                ButtonCommit.IsEnabled = true;
                return;
            }
            if (province.Length > 20 || city.Length > 20)
            {
                State.AddMessage = "参数太长";
                ButtonCommit.IsEnabled = true;
                return;
            }

            await HttpClient.AddDestAsync(province, city);

            ButtonCommit.IsEnabled = true;
            await Task.Delay(3000);
            PageNavigator.PopupClose();

        }

        public PageNavigator PageNavigator => App.Current.ServiceProvider.GetService<PageNavigator>();
        public GradeHttpClient HttpClient => App.Current.ServiceProvider.GetService<GradeHttpClient>();
        public GlobalState State => App.Current.ServiceProvider.GetService<GlobalState>();
    }
}
