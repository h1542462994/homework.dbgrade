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

        #region StateGetter&Setter

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

        public ReplaceCollection<FrameWork.Dto.Province> Provinces
        {
            get { return (ReplaceCollection<FrameWork.Dto.Province>)GetValue(ProvincesProperty); }
            set { SetValue(ProvincesProperty, value); }
        }

        public ReplaceCollection<FrameWork.Dto.City> Cities
        {
            get { return (ReplaceCollection<FrameWork.Dto.City>)GetValue(CitiesProperty); }
            set { SetValue(CitiesProperty, value); }
        }

        public ReplaceCollection<int> CYears
        {
            get { return (ReplaceCollection<int>)GetValue(CYearsProperty); }
            set { SetValue(CYearsProperty, value); }
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

        public int CYearIndex
        {
            get {
                int v = (int)GetValue(CYearIndexProperty);
                if (v > 0 && v < CYears.Count)
                {
                    return v;
                } else
                {
                    return 0;
                }
            }
            set {
                SetValue(CYearIndexProperty, value);
            }
        }

        public int ProvinceIndex
        {
            get { return (int)GetValue(ProvinceIndexProperty); }
            set { SetValue(ProvinceIndexProperty, value); }
        }
        public int CityIndex
        {
            get { return (int)GetValue(CityIndexProperty); }
            set { SetValue(CityIndexProperty, value); }
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
        public bool IsDestStructFetchEnabled
        {
            get { return (bool)GetValue(IsDestStructFetchEnabledProperty); }
            set { SetValue(IsDestStructFetchEnabledProperty, value); }
        }

        #endregion

        public GradeHttpClient HttpClient { get; }

        public async void FetchStudent()
        {
            Locator locator = GetLocator();
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
                            if (index >= 0 && index < StudentStruct.Count)
                            {
                                ProfessionIndex = index;
                            } else
                            {
                                ProfessionIndex = 0;
                            }

                            var cYearIndex = CYearIndex;

                            HashSet<int> sets = new HashSet<int>();
                            sets.Add(-1);


                            foreach (var item in studentStruct)
                            {
                                foreach (var item2 in item.Xclasses)
                                {
                                    sets.Add(item2.Year);
                                }
                            }

                            CYears.ReplaceItems(sets.OrderBy(item => item));

                            if (cYearIndex > 0 && cYearIndex < CYears.Count)
                            {
                                CYearIndex = cYearIndex;
                            }
                            else
                            {
                                CYearIndex = 0;
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
        public async void FetchDestStruct()
        {
            if (IsDestStructFetchEnabled)
            {
                App.Dispatcher.Invoke(() =>
                {
                    IsDestStructFetchEnabled = false;
                });

                var provinces = await HttpClient.GetDestStructAsync();
                lock (Provinces)
                {
                    App.Dispatcher.Invoke(() =>
                    {
                        if (provinces == null)
                        {
                            Message = "加载错误";
                        }
                        else
                        {
                            int index = ProvinceIndex;
                            Provinces.ReplaceItems(provinces);
                            Provinces.Insert(0, FrameWork.Dto.Province.All);
                            if (index >= 0 && index < Provinces.Count)
                            {
                                ProvinceIndex = index;
                            } else
                            {
                                ProvinceIndex = 0;
                            }
                        }
                    });
                }

                App.Dispatcher.Invoke(() =>
                {
                    IsDestStructFetchEnabled = true;
                });
            }
        }
        private Locator GetLocator()
        {
            int? cYear = CYears[CYearIndex] <= 0 ? default(int?) : CYears[CYearIndex];
            if (ModeIndex == 0)
            {
                if (ProfessionIndex <= 0)
                {
                    return Locator.All(cYear);
                }
                else
                {
                    var profession = StudentStruct[ProfessionIndex];
                    if (ClassIndex <= 0)
                    {
                        return Locator.Profession(profession.Pno, cYear);
                    } 
                    else
                    {
                        var xclass = Xclasses[ClassIndex];
                        return Locator.Xclass(xclass.Cno, cYear);
                    }
                }
            }
            else if (ModeIndex == 1)
            {
                if (ProvinceIndex <= 0)
                {
                    return Locator.All(cYear);
                } 
                else
                {
                    var province = Provinces[ProvinceIndex];
                    if (CityIndex <= 0)
                    {
                        return Locator.Province(province.Prno, cYear);
                    } 
                    else
                    {
                        var city = Cities[CityIndex];
                        return Locator.City(city.Cino, cYear);
                    }
                }
            }
            return Locator.All();
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
                var cyear = CYears[CYearIndex];
                Xclasses.ReplaceItems(from item in StudentStruct[ProfessionIndex].Xclasses where cyear <= 0 || cyear == item.Year select item);
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

        private void OnUpdateCities()
        {
            if (ProvinceIndex <= 0 || ProvinceIndex >= Provinces.Count)
            {
                Cities.ReplaceItems(new[] { FrameWork.Dto.City.All });
                CityIndex = 0;
            }
            else
            {
                var cityIndex = CityIndex;
                Cities.ReplaceItems(Provinces[ProvinceIndex].Cities);
                Cities.Insert(0, FrameWork.Dto.City.All);
                if (cityIndex < Cities.Count)
                {
                    CityIndex = cityIndex;
                } else
                {
                    CityIndex = 0;
                }
            }
        }

        public static readonly DependencyProperty StudentOutViewProperty =
            DependencyProperty.Register(nameof(StudentOutView),
                typeof(ReplaceCollection<StudentOutView>),
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<StudentOutView>((left, right) => left.Sno.CompareTo(right.Sno))));


        #region StateDependencyProperty

        public static readonly DependencyProperty StudentStructProperty =
            DependencyProperty.Register(nameof(StudentStruct),
                typeof(ReplaceCollection<FrameWork.Dto.Profession>),
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.Profession>((left, right) => left.Pno.CompareTo(right.Pno)) {
                    FrameWork.Dto.Profession.All
                }));

        public static readonly DependencyProperty XclassesProperty =
            DependencyProperty.Register(nameof(Xclasses), 
                typeof(ReplaceCollection<FrameWork.Dto.Xclass>), 
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.Xclass>((left, right) => left.Cno.CompareTo(right.Cno)) { 
                    FrameWork.Dto.Xclass.All
                }));


        public static readonly DependencyProperty ProvincesProperty =
            DependencyProperty.Register(nameof(Provinces),
                typeof(ReplaceCollection<FrameWork.Dto.Province>),
                typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.Province>((left, right) => left.Prno.CompareTo(right.Prno)) {
                    FrameWork.Dto.Province.All
                }));

        public static readonly DependencyProperty CitiesProperty =
            DependencyProperty.Register(nameof(Cities), typeof(ReplaceCollection<FrameWork.Dto.City>), typeof(RemoteStorage),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.City>((left, right) => left.Cino.CompareTo(right.Cino)) {
                    FrameWork.Dto.City.All
                }));

        public static readonly DependencyProperty CYearsProperty =
            DependencyProperty.Register("CYears", typeof(ReplaceCollection<int>), typeof(RemoteStorage), new PropertyMetadata(new ReplaceCollection<int>() { -1 }));

        public static readonly DependencyProperty ModeIndexProperty =
            DependencyProperty.Register(nameof(ModeIndex), typeof(int), typeof(RemoteStorage), new PropertyMetadata(0));

        public static readonly DependencyProperty CYearIndexProperty =
            DependencyProperty.Register("CYearIndex", typeof(int), typeof(RemoteStorage),
                new PropertyMetadata(0, (d, e) => {
                    var dobj = (RemoteStorage)d;
                    dobj.OnUpdateXclass();
                }));

        public static readonly DependencyProperty ProfessionIndexProperty =
        DependencyProperty.Register(nameof(ProfessionIndex), typeof(int), typeof(RemoteStorage), 
            new PropertyMetadata(0, (d, e) => {
                var dobj = (RemoteStorage)d;
                dobj.OnUpdateXclass();
            }));

        public static readonly DependencyProperty ClassIndexProperty =
            DependencyProperty.Register(nameof(ClassIndex), typeof(int), typeof(RemoteStorage), new PropertyMetadata(0));

        public static readonly DependencyProperty ProvinceIndexProperty =
            DependencyProperty.Register(nameof(ProvinceIndex), typeof(int), typeof(RemoteStorage), 
                new PropertyMetadata(0, (d,e) => {
                    var dobj = (RemoteStorage)d;
                    dobj.OnUpdateCities();
                }));

        public static readonly DependencyProperty CityIndexProperty =
            DependencyProperty.Register(nameof(CityIndex), typeof(int), typeof(RemoteStorage), new PropertyMetadata(0));

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof(string), typeof(RemoteStorage), new PropertyMetadata(""));

        public static readonly DependencyProperty IsStudentOutViewFetchingEnabledProperty =
            DependencyProperty.Register(nameof(IsStudentOutViewFetchingEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsStudentStructFetchingEnabledProperty =
            DependencyProperty.Register(nameof(IsStudentStructFetchingEnabled), typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        public static readonly DependencyProperty IsDestStructFetchEnabledProperty =
            DependencyProperty.Register("IsDestStructFetchEnabled", typeof(bool), typeof(RemoteStorage), new PropertyMetadata(true));

        #endregion
    }
}
