using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows;
using Tro.DbGrade.FrameWork.Models;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class RemoteStorage : DependencyObject
    {
        public RemoteStorage(App app, GradeHttpClient httpClient, SelectorViewModel selectorViewModel, GlobalState state)
        {
            App = app;
            HttpClient = httpClient;
            SelectorViewModel = selectorViewModel;
            State = state;
        }

  
        public App App { get; }

        public ReplaceCollection<StudentOutView> StudentOutView
        {
            get { return (ReplaceCollection<StudentOutView>)GetValue(StudentOutViewProperty); }
            set { SetValue(StudentOutViewProperty, value); }
        }

        #region StateGetter&Setter

        public bool IsStudentOutViewFetchingEnabled
        {
            get { return (bool)GetValue(IsStudentOutViewFetchingEnabledProperty); }
            set { SetValue(IsStudentOutViewFetchingEnabledProperty, value); }
        }

        #endregion

        public GradeHttpClient HttpClient { get; }
        public SelectorViewModel SelectorViewModel { get; }
        public GlobalState State { get; }

        public async void FetchStudent()
        {
            Locator locator = SelectorViewModel.GetLocator();
            if (IsStudentOutViewFetchingEnabled)
            {
                App.Dispatcher.Invoke(() =>
                {
                    IsStudentOutViewFetchingEnabled = false;
                });

                var students = await HttpClient.GetStudentsAsync(locator.Scope, locator.Tag, locator.CYear);
                lock (StudentOutView)
                {
                    App.Dispatcher.Invoke(() =>
                    {
                        if (students == null)
                        {
                            State.Message = "加载错误";
                        }
                        else
                        {
                            StudentOutView.ReplaceItems(students);
                        }
                    });
                }

                App.Dispatcher.Invoke(()=> {
                    IsStudentOutViewFetchingEnabled = true;
                });
                
            }
        }



        public static readonly DependencyProperty StudentOutViewProperty =
            DependencyProperty.Register(nameof(StudentOutView),
                typeof(ReplaceCollection<StudentOutView>),
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<StudentOutView>((left, right) => left.Sno.CompareTo(right.Sno))));


        #region StateDependencyProperty



        public static readonly DependencyProperty IsStudentOutViewFetchingEnabledProperty =
            DependencyProperty.Register(nameof(IsStudentOutViewFetchingEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));



        #endregion
    }
}
