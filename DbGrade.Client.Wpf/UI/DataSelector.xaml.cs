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

namespace Tro.DbGrade.Client.Wpf.UI
{
    /// <summary>
    /// DataSelector.xaml 的交互逻辑
    /// </summary>
    public partial class DataSelector : UserControl
    {
        public DataSelector()
        {
            InitializeComponent();
            Loaded += DataSelector_Loaded;
        }

        private void DataSelector_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonFresh.Click += async (o, e) =>
            {
                ButtonFresh.IsEnabled = false;
                SelectorViewModel.FetchData();
                await Task.Delay(2000);
                ButtonFresh.IsEnabled = true;
            };
        }

        public RemoteStorage RemoteStorage => App.Current.ServiceProvider.GetService<RemoteStorage>();
        public SelectorViewModel SelectorViewModel => App.Current.ServiceProvider.GetService<SelectorViewModel>();
    }
}
