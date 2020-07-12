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
        public RemoteStorage(App app, GradeHttpClient httpClient)
        {
            App = app;
            HttpClient = httpClient;
        }

  
        public App App { get; }

        public ReplaceCollection<StudentOutView> StudentOutView
        {
            get { return (ReplaceCollection<StudentOutView>)GetValue(StudentOutViewProperty); }
            set { SetValue(StudentOutViewProperty, value); }
        }



        public ReplaceCollection<FrameWork.Dto.Profession> StudentStruct
        {
            get { return (ReplaceCollection<FrameWork.Dto.Profession>)GetValue(StudentStructProperty); }
            set { SetValue(StudentStructProperty, value); }
        }


        public ReplaceCollection<FrameWork.Dto.Xclass> Xclasses
        {
            get { return (ReplaceCollection<FrameWork.Dto.Xclass>)GetValue(XclassesProperty); }
            set { SetValue(XclassesProperty, value); }
        }



        public int ModeIndex
        {
            get { return (int)GetValue(ModeIndexProperty); }
            set { SetValue(ModeIndexProperty, value); }
        }

        public int ProfessionIndex
        {
            get { return (int)GetValue(ProfessionIndexProperty); }
            set { SetValue(ProfessionIndexProperty, value); }
        }

        public int ClassIndex
        {
            get { return (int)GetValue(ClassIndexProperty); }
            set { SetValue(ClassIndexProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        public bool IsStudentOutViewFetchingEnabled
        {
            get { return (bool)GetValue(IsStudentOutViewFetchingEnabledProperty); }
            set { SetValue(IsStudentOutViewFetchingEnabledProperty, value); }
        }
        public bool IsStudentStructFetchingEnabled
        {
            get { return (bool)GetValue(IsStudentStructFetchingEnabledProperty); }
            set { SetValue(IsStudentStructFetchingEnabledProperty, value); }
        }



        public GradeHttpClient HttpClient { get; }

        public async void FetchStudent(string scope = Scope.All, int? tag = null, int? year = null)
        {
            if (IsStudentOutViewFetchingEnabled)
            {
                App.Dispatcher.Invoke(() =>
                {
                    IsStudentOutViewFetchingEnabled = false;
                });

                var students = await HttpClient.GetStudentsAsync(scope, tag, year);
                lock (StudentOutView)
                {
                    App.Dispatcher.Invoke(() =>
                    {
                        if (students == null)
                        {
                            Message = "加载错误";
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
        public async void FetchStudentStruct()
        {
            if (IsStudentStructFetchingEnabled)
            {
                App.Dispatcher.Invoke(() =>
                {
                    IsStudentStructFetchingEnabled = false;
                });
                
                var studentStruct = await HttpClient.GetStudentStructAsync();
                lock (StudentStruct)
                {
                    App.Dispatcher.Invoke(()=> {
                        if (studentStruct == null)
                        {
                            Message = "加载错误";
                        } 
                        else
                        {
                            int index = ProfessionIndex;
                            StudentStruct.ReplaceItems(studentStruct);
                            StudentStruct.Insert(0, FrameWork.Dto.Profession.All);
                            if (ProfessionIndex >= 0 && ProfessionIndex < StudentStruct.Count)
                            {
                                ProfessionIndex = index;
                            } else
                            {
                                ProfessionIndex = 0;
                            }
                            OnUpdateXclass();
                        }
                    });
                }

                App.Dispatcher.Invoke(() =>
                {
                    IsStudentStructFetchingEnabled = true;
                });
            }
        }

        private void OnUpdateXclass()
        {
            if (ProfessionIndex <= 0 || ProfessionIndex >= StudentStruct.Count)
            {
                Xclasses.ReplaceItems( new[] { FrameWork.Dto.Xclass.All });
                ClassIndex = 0;
            } 
            else
            {
                var classIndex = ClassIndex;
               // Xclasses.Clear();
                Xclasses.ReplaceItems(StudentStruct[ProfessionIndex].Xclasses);
                Xclasses.Insert(0, FrameWork.Dto.Xclass.All);
                //foreach (var item in StudentStruct[ProfessionIndex].Xclasses)
                //{
                //    Xclasses.Add(item);
                //}
                if (classIndex < Xclasses.Count)
                {
                    ClassIndex = classIndex;
                } else
                {
                    ClassIndex = 0;
                }
            }

        }

        public static readonly DependencyProperty StudentOutViewProperty =
            DependencyProperty.Register(nameof(StudentOutView),
                typeof(ReplaceCollection<StudentOutView>),
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<StudentOutView>((left, right) => left.Sno.CompareTo(right.Sno))));

        public static readonly DependencyProperty StudentStructProperty =
            DependencyProperty.Register(nameof(StudentStruct),
                typeof(ReplaceCollection<FrameWork.Dto.Profession>),
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.Profession>((left, right) => left.Pno.CompareTo(right.Pno)) {
                    FrameWork.Dto.Profession.All
                }, (d,e) => {
                    var dobj = (RemoteStorage)d;
                    dobj.OnUpdateXclass();
                }));

        public static readonly DependencyProperty XclassesProperty =
            DependencyProperty.Register(nameof(Xclasses), 
                typeof(ReplaceCollection<FrameWork.Dto.Xclass>), 
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.Xclass>((left, right) => left.Cno.CompareTo(right.Cno)) { 
                    FrameWork.Dto.Xclass.All
                }));

        public static readonly DependencyProperty ModeIndexProperty =
            DependencyProperty.Register(nameof(ModeIndex), typeof(int), typeof(RemoteStorage), new PropertyMetadata(0));

        public static readonly DependencyProperty ProfessionIndexProperty =
        DependencyProperty.Register(nameof(ProfessionIndex), typeof(int), typeof(RemoteStorage), 
            new PropertyMetadata(0, (d, e) => {
                var dobj = (RemoteStorage)d;
                dobj.OnUpdateXclass();
            }));

        public static readonly DependencyProperty ClassIndexProperty =
            DependencyProperty.Register(nameof(ClassIndex), typeof(int), typeof(RemoteStorage), new PropertyMetadata(0));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof(string), typeof(RemoteStorage), new PropertyMetadata(""));

        public static readonly DependencyProperty IsStudentOutViewFetchingEnabledProperty =
            DependencyProperty.Register(nameof(IsStudentOutViewFetchingEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsStudentStructFetchingEnabledProperty =
            DependencyProperty.Register(nameof(IsStudentStructFetchingEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));
    }
}
