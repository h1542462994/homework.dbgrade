using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows;
using Tro.DbGrade.FrameWork.Models;
using Tro.DbGrade.FrameWork.Dto;

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
        public GradeHttpClient HttpClient { get; }
        public SelectorViewModel SelectorViewModel { get; }
        public GlobalState State { get; }

        #region Datas

        public ReplaceCollection<StudentOut> StudentOut
        {
            get { return (ReplaceCollection<StudentOut>)GetValue(StudentOutProperty); }
            set { SetValue(StudentOutProperty, value); }
        }

        public ReplaceCollection<DestSummary> DestSummaries
        {
            get { return (ReplaceCollection<DestSummary>)GetValue(DestSummariesProperty); }
            set { SetValue(DestSummariesProperty, value); }
        }

        public ReplaceCollection<ClassSummary> ClassSummaries
        {
            get { return (ReplaceCollection<ClassSummary>)GetValue(ClassSummariesProperty); }
            set { SetValue(ClassSummariesProperty, value); }
        }

        public ReplaceCollection<ReportsView> Reports
        {
            get { return (ReplaceCollection<ReportsView>)GetValue(ReportsProperty); }
            set { SetValue(ReportsProperty, value); }
        }

        public ReplaceCollection<Teacher> Teachers
        {
            get { return (ReplaceCollection<Teacher>)GetValue(TeachersProperty); }
            set { SetValue(TeachersProperty, value); }
        }

        public ReplaceCollection<ReportSummaryOut> ReportSummaries
        {
            get { return (ReplaceCollection<ReportSummaryOut>)GetValue(ReportSummariesProperty); }
            set { SetValue(ReportSummariesProperty, value); }
        }

        public ReplaceCollection<XTerm> Terms
        {
            get { return (ReplaceCollection<XTerm>)GetValue(TermsProperty); }
            set { SetValue(TermsProperty, value); }
        }

        public ReplaceCollection<CourseSummaryView> CourseSummaries
        {
            get { return (ReplaceCollection<CourseSummaryView>)GetValue(CourseSummariesProperty); }
            set { SetValue(CourseSummariesProperty, value); }
        }
        public ReplaceCollection<Course> Courses
        {
            get { return (ReplaceCollection<Course>)GetValue(CoursesProperty); }
            set { SetValue(CoursesProperty, value); }
        }
        #endregion

        #region StateGetter&Setter

        public bool IsStudentOutViewFetchingEnabled
        {
            get { return (bool)GetValue(IsStudentOutViewFetchingEnabledProperty); }
            set { SetValue(IsStudentOutViewFetchingEnabledProperty, value); }
        }

        public bool IsDestSummaryFetchEnabled
        {
            get { return (bool)GetValue(IsDestSummaryFetchEnabledProperty); }
            set { SetValue(IsDestSummaryFetchEnabledProperty, value); }
        }
        public bool IsClassSummariesFetchEnabled
        {
            get { return (bool)GetValue(IsClassSummariesFetchEnabledProperty); }
            set { SetValue(IsClassSummariesFetchEnabledProperty, value); }
        }
        public bool IsReportsFetchEnabled
        {
            get { return (bool)GetValue(IsReportsFetchEnabledProperty); }
            set { SetValue(IsReportsFetchEnabledProperty, value); }
        }

        public bool IsTeacherFetchEnabled
        {
            get { return (bool)GetValue(IsTeacherFetchEnabledProperty); }
            set { SetValue(IsTeacherFetchEnabledProperty, value); }
        }

        public bool IsReportSummariesFetchEnabled
        {
            get { return (bool)GetValue(IsReportSummariesFetchEnabledProperty); }
            set { SetValue(IsReportSummariesFetchEnabledProperty, value); }
        }
        public bool IsTermsFetchEnabled
        {
            get { return (bool)GetValue(IsTermsFetchEnabledProperty); }
            set { SetValue(IsTermsFetchEnabledProperty, value); }
        }
        public bool IsCourseSummariesFetchEnabled
        {
            get { return (bool)GetValue(IsCourseSummariesFetchEnabledProperty); }
            set { SetValue(IsCourseSummariesFetchEnabledProperty, value); }
        }
        public bool IsCourseFetchEnabled
        {
            get { return (bool)GetValue(IsCourseFetchEnabledProperty); }
            set { SetValue(IsCourseFetchEnabledProperty, value); }
        }

        #endregion

        #region Fetches

        public async void FetchStudentsAsync()
        {
            Locator locator = SelectorViewModel.GetLocator();

            App.Dispatcher.Invoke(() => IsStudentOutViewFetchingEnabled = false);

            var students = await HttpClient.GetStudentsAsync(locator.Scope, locator.Tag, locator.CYear);
            lock (StudentOut)
            {
                App.Dispatcher.Invoke(() =>
                {
                    if (students == null)
                    {
                        State.Message = "加载错误";
                    }
                    else
                    {
                        StudentOut.ReplaceItems(students);
                    }
                });
            }

            App.Dispatcher.Invoke(()=> IsStudentOutViewFetchingEnabled = true);
        }

        public async void FetchDestSummaryAsync()
        {
            Locator locator = SelectorViewModel.GetLocator();
            App.Dispatcher.Invoke(() => IsDestSummaryFetchEnabled = false);

            var dests = await HttpClient.GetDestSummariesAysnc(locator.Scope, locator.Tag, locator.CYear);
            lock (DestSummaries)
            {
                App.Dispatcher.Invoke(() => {
                    if (dests == null)
                    {
                        State.Message = "加载错误";
                    } 
                    else
                    {
                        DestSummaries.ReplaceItems(dests);
                    }
                });
            }

            App.Dispatcher.Invoke(() => IsDestSummaryFetchEnabled = true);
        }

        public async void FetchClassSummaryAsync()
        {
            Locator locator = SelectorViewModel.GetLocator();
            App.Dispatcher.Invoke(() => IsClassSummariesFetchEnabled = false);

            var classes = await HttpClient.GetClassSummariesAsync(locator.Scope, locator.Tag, locator.CYear);
            lock (ClassSummaries)
            {
                App.Dispatcher.Invoke(() =>
                {
                    if (classes == null)
                    {
                        State.Message = "加载错误";
                    }
                    else
                    {
                        ClassSummaries.ReplaceItems(classes);
                    }
                });
            }

            App.Dispatcher.Invoke(()=> IsClassSummariesFetchEnabled = true);
        }

        public async void FetchReportsAsync()
        {
            Locator locator = SelectorViewModel.GetLocator();
            App.Dispatcher.Invoke(() => IsReportsFetchEnabled = false );

            var reports = await HttpClient.GetReportsAsync(locator.Scope, locator.Tag, locator.Year, locator.CYear);
            lock (Reports)
            {
                App.Dispatcher.Invoke(() =>
                {
                    if (reports == null)
                    {
                        State.Message = "加载错误";
                    } else
                    {
                        Reports.ReplaceItems(reports);   
                    }
                });
            }

            App.Dispatcher.Invoke(() => IsReportsFetchEnabled = true );
        }

        public async void FetchTeachersAsync()
        {
            App.Dispatcher.Invoke(() => IsTeacherFetchEnabled = false);

            var teachers = await HttpClient.GetTeachersAsync();
            lock (teachers)
            {
                App.Dispatcher.Invoke(() =>
                {
                    if (teachers == null)
                    {
                        State.Message = "加载错误";
                    }
                    else
                    {
                        Teachers.ReplaceItems(teachers);
                    }
                });
            }

            App.Dispatcher.Invoke(() => IsTeacherFetchEnabled = true);
        }

        public async void FetchReportSummariesAsync()
        {
            App.Dispatcher.Invoke(() => IsReportSummariesFetchEnabled = false);

            var locator = SelectorViewModel.GetLocator();
            var reportSummaries = await HttpClient.GetReportSummariesAsync(locator.Scope, locator.Tag, locator.Year, locator.CYear);

            lock (ReportSummaries)
            {
                App.Dispatcher.Invoke(() =>
                {
                    if (reportSummaries == null)
                    {
                        State.Message = "加载错误";
                    }
                    else
                    {
                        ReportSummaries.ReplaceItems(reportSummaries);
                    }
                });
            }

            App.Dispatcher.Invoke(() => IsReportSummariesFetchEnabled = true);
        }

        public async void FetchTermsAsync()
        {
            App.Dispatcher.Invoke(() => IsTermsFetchEnabled = false);

            var terms = await HttpClient.GetTermsAsync();
            lock (Terms)
            {
                App.Dispatcher.Invoke(() => {
                    if (terms == null)
                    {
                        State.Message = "加载错误";
                    }
                    else
                    {
                        Terms.ReplaceItems(terms);
                    }
                });
            }

            App.Dispatcher.Invoke(() => IsTermsFetchEnabled = true);
        }

        public async void FetchCourseSummaryAsync()
        {
            App.Dispatcher.Invoke(() => IsCourseSummariesFetchEnabled = false);

            var locator = SelectorViewModel.GetLocator();
            var courseSummaries = await HttpClient.GetCourseSummariesAsync(locator.Scope, locator.Tag, locator.Year, locator.CYear);
            lock (CourseSummaries)
            {
                App.Dispatcher.Invoke(() => {
                    if (courseSummaries == null)
                    {
                        State.Message = "加载错误";
                    }
                    else
                    {
                        CourseSummaries.ReplaceItems(courseSummaries);
                    }
                });
            }

            App.Dispatcher.Invoke(() => IsCourseSummariesFetchEnabled = true);
        }

        public async void FetchCoursesAsync()
        {
            App.Dispatcher.Invoke(() => IsCourseFetchEnabled = false);
            var courses = await HttpClient.GetCoursesAysnc();
            lock (Courses)
            {
                App.Dispatcher.Invoke(() =>
                {
                    if (courses == null)
                    {
                        State.Message = "加载错误";
                    }
                    else
                    {
                        Courses.ReplaceItems(courses);
                    }
                });
            }
            App.Dispatcher.Invoke(() => IsCourseFetchEnabled = true);
        }

        #endregion

        #region DataProperties

        public static readonly DependencyProperty StudentOutProperty =
            DependencyProperty.Register(nameof(StudentOut),
                typeof(ReplaceCollection<StudentOut>),
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<StudentOut>()));

        public static readonly DependencyProperty DestSummariesProperty =
            DependencyProperty.Register(nameof(DestSummaries), 
                typeof(ReplaceCollection<DestSummary>), 
                typeof(RemoteStorage), 
                new PropertyMetadata(
                    new ReplaceCollection<DestSummary>()));
        public static readonly DependencyProperty ClassSummariesProperty =
            DependencyProperty.Register(
                nameof(ClassSummaries),
                typeof(ReplaceCollection<ClassSummary>),
                typeof(RemoteStorage), new PropertyMetadata(
                    new ReplaceCollection<ClassSummary>()
                    ));

        public static readonly DependencyProperty ReportsProperty =
            DependencyProperty.Register(
                nameof(Reports),
                typeof(ReplaceCollection<ReportsView>),
                typeof(RemoteStorage),
                new PropertyMetadata(
                    new ReplaceCollection<ReportsView>()
                    ));
        public static readonly DependencyProperty TeachersProperty =
            DependencyProperty.Register(nameof(Teachers), 
                typeof(ReplaceCollection<Teacher>),
                typeof(RemoteStorage), 
                new PropertyMetadata(
                    new ReplaceCollection<Teacher>()
                    ));

        public static readonly DependencyProperty ReportSummariesProperty =
            DependencyProperty.Register(nameof(ReportSummaries),
                typeof(ReplaceCollection<ReportSummaryOut>), 
                typeof(RemoteStorage), 
                new PropertyMetadata(
                    new ReplaceCollection<ReportSummaryOut>()
                    ));

        public static readonly DependencyProperty CourseSummariesProperty =
            DependencyProperty.Register(
                nameof(CourseSummaries), 
                typeof(ReplaceCollection<CourseSummaryView>), 
                typeof(RemoteStorage), 
                new PropertyMetadata(
                    new ReplaceCollection<CourseSummaryView>()
                    ));

        #endregion

        #region StateDependencyProperty

        public static readonly DependencyProperty IsDestSummaryFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsDestSummaryFetchEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsStudentOutViewFetchingEnabledProperty =
            DependencyProperty.Register(nameof(IsStudentOutViewFetchingEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsClassSummariesFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsClassSummariesFetchEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsReportsFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsReportsFetchEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsTeacherFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsTeacherFetchEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsReportSummariesFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsReportSummariesFetchEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty TermsProperty =
            DependencyProperty.Register(nameof(Terms), typeof(ReplaceCollection<XTerm>), typeof(RemoteStorage), new PropertyMetadata(new ReplaceCollection<XTerm>()));

        public static readonly DependencyProperty IsTermsFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsTermsFetchEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsCourseSummariesFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsCourseSummariesFetchEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));
     
        public static readonly DependencyProperty IsCourseFetchEnabledProperty =
            DependencyProperty.Register("IsCourseFetchEnabled", typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty CoursesProperty =
            DependencyProperty.Register("Courses", typeof(ReplaceCollection<Course>), typeof(RemoteStorage), new PropertyMetadata(new ReplaceCollection<Course>()));

        #endregion
    }
}
