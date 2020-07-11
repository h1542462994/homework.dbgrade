using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tro.DbGrade.FrameWork.Models;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class RemoteStorage
    {
        public RemoteStorage(App app, GradeHttpClient httpClient)
        {
            App = app;
            HttpClient = httpClient;
        }

        public ObservableCollection<StudentOutView> StudentOutView { get; } = new ObservableCollection<StudentOutView>();
        public App App { get; }
        public GradeHttpClient HttpClient { get; }

        public async void FetchStudent()
        {

        }
    }
}
