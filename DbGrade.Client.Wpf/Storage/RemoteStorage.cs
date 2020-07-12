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

        public bool IsFetching { get; private set; } = false;
        public string Message { get; set; }
        public KeyMapperCollection<string, StudentOutView> StudentOutView { get; } = new KeyMapperCollection<string, StudentOutView>(item => item.Sno);
        public App App { get; }
        public GradeHttpClient HttpClient { get; }

        public async void FetchStudent(string scope = Scope.All, int? tag = null, int? year = null)
        {
            if (!IsFetching)
            {
                IsFetching = true;

                var students = await HttpClient.GetStudentsAsync(scope, tag, year);
                lock (StudentOutView)
                {
                    App.Dispatcher.Invoke(() =>
                    {
                        if (students == null)
                        {
                            Message = "加载错误";
                        } else
                        {
                            StudentOutView.ReplaceItems(students);
                        }
                    });
                }

                IsFetching = false;
            }
        }
    }
}
