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
    /// ReportSummaryPage.xaml 的交互逻辑
    /// </summary>
    public partial class ReportSummaryPage : Page
    {
        public ReportSummaryPage()
        {
            InitializeComponent();
            Loaded += ReportSummaryPage_Loaded;
        }

        private void ReportSummaryPage_Loaded(object sender, RoutedEventArgs e)
        {
            SelectorViewModel.SelectorMode = SelectorMode.StructDest;
            ButtonQuery.Click += (o, e) => RemoteStorage.FetchReportSummariesAsync();
        }

        public SelectorViewModel SelectorViewModel => App.Current.ServiceProvider.GetService<SelectorViewModel>();
        public RemoteStorage RemoteStorage => App.Current.ServiceProvider.GetService<RemoteStorage>();
    }
}
