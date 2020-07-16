using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using Tro.DbGrade.FrameWork.Dto;
using Tro.DbGrade.FrameWork.Models;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class SelectorViewModel : DependencyObject
    {
        public SelectorViewModel(App app, GradeHttpClient httpClient, GlobalState state)
        {
            App = app;
            HttpClient = httpClient;
            State = state;
            timer = new DispatcherTimer(DispatcherPriority.ApplicationIdle, App.Dispatcher)
            {
                Interval = TimeSpan.FromMinutes(1)
            };
            timer.Tick += (o, e) => FetchData();
            FetchData();
        }
        private readonly DispatcherTimer timer;

        public ReplaceCollection<FrameWork.Dto.Profession> Professions
        {
            get { return (ReplaceCollection<FrameWork.Dto.Profession>)GetValue(ProfessionsProperty); }
            set { SetValue(ProfessionsProperty, value); }
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

        public ReplaceCollection<int> Years
        {
            get { return (ReplaceCollection<int>)GetValue(YearsProperty); }
            set { SetValue(YearsProperty, value); }
        }


        public ReplaceCollection<Teacher> Teachers
        {
            get { return (ReplaceCollection<Teacher>)GetValue(TeachersProperty); }
            set { SetValue(TeachersProperty, value); }
        }
        public ReplaceCollection<Course> Courses
        {
            get { return (ReplaceCollection<Course>)GetValue(CoursesProperty); }
            set { SetValue(CoursesProperty, value); }
        }

        public ReplaceCollection<StudentOut> Students
        {
            get { return (ReplaceCollection<StudentOut>)GetValue(StudentsProperty); }
            set { SetValue(StudentsProperty, value); }
        }

        public int StudentIndex
        {
            get {
                int v =  (int)GetValue(StudentIndexProperty);
                if (v >= 0 && v < Students.Count)
                {
                    return v;
                } else
                {
                    return 0;
                }
            }
            set { SetValue(StudentIndexProperty, value); }
        }

        public int ModeIndex
        {
            get
            {
                int v = (int)GetValue(ModeIndexProperty);
                if (v > 0 && v < Modes.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set { SetValue(ModeIndexProperty, value); }
        }


        public int ProfessionIndex
        {
            get
            {
                int v = (int)GetValue(ProfessionIndexProperty);
                if (v > 0 && v < Professions.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set { SetValue(ProfessionIndexProperty, value); }
        }

        public FrameWork.Dto.Profession Profession{
            get
            {
                if (Mode == LocatorMode.Struct)
                {
                    return Professions[ProfessionIndex];
                } 
                else
                {
                    return FrameWork.Dto.Profession.All;
                }
            }    
        }

        public int ClassIndex
        {
            get
            {
                int v = (int)GetValue(ClassIndexProperty);
                if (v > 0 && v < Xclasses.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set { SetValue(ClassIndexProperty, value); }
        }

        public StudentOut Student
        {
            get
            {
                if (StudentIndex > 0 && StudentIndex < Students.Count)
                {
                    return Students[StudentIndex];
                } else
                {
                    return null;
                }
            }
        }
        public int CYearIndex
        {
            get
            {
                int v = (int)GetValue(CYearIndexProperty);
                if (v > 0 && v < CYears.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                SetValue(CYearIndexProperty, value);
            }
        }

        public int YearIndex
        {
            get {
                int v = (int)GetValue(YearIndexProperty);
                if (v > 0 && v < Years.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set { SetValue(YearIndexProperty, value); }
        }

        public int ProvinceIndex
        {
            get
            {
                int v = (int)GetValue(ProvinceIndexProperty);
                if (v > 0 && v < Provinces.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set { SetValue(ProvinceIndexProperty, value); }
        }

        public FrameWork.Dto.Province Province
        {
            get
            {
                if (Mode == LocatorMode.Dest)
                {
                    return Provinces[ProvinceIndex];
                } else
                {
                    return FrameWork.Dto.Province.All;
                }
            }
        }

        public int CityIndex
        {
            get
            {
                int v = (int)GetValue(CityIndexProperty);
                if (v > 0 && v < Cities.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set { SetValue(CityIndexProperty, value); }
        }

        public int TeacherIndex
        {
            get
            {
                int v = (int)GetValue(TeacherIndexProperty);
                if (v > 0 && v < Teachers.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set { SetValue(TeacherIndexProperty, value); }
        }
        public int CourseIndex
        {
            get
            {
                int v = (int)GetValue(CourseIndexProperty);
                if (v > 0 && v < Courses.Count)
                {
                    return v;
                }
                else
                {
                    return 0;
                }
            }
            set { SetValue(CourseIndexProperty, value); }
        }
        public LocatorMode Mode
        {
            get { return (LocatorMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
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

        public bool IsYearsFetchEnabled
        {
            get { return (bool)GetValue(IsYearsFetchEnabledProperty); }
            set { SetValue(IsYearsFetchEnabledProperty, value); }
        }
        public bool IsTeacherFetchEnabled
        {
            get { return (bool)GetValue(IsTeacherFetchEnabledProperty); }
            set { SetValue(IsTeacherFetchEnabledProperty, value); }
        }
        public bool IsCourseFetchEnabled
        {
            get { return (bool)GetValue(IsCourseFetchEnabledProperty); }
            set { SetValue(IsCourseFetchEnabledProperty, value); }
        }
        public bool IsStudentFetchEnabled
        {
            get { return (bool)GetValue(IsStudentFetchEnabledProperty); }
            set { SetValue(IsStudentFetchEnabledProperty, value); }
        }

        public SelectorMode SelectorMode
        {
            get { return (SelectorMode)GetValue(SelectorModeProperty); }
            set { SetValue(SelectorModeProperty, value); }
        }

        public App App { get; }
        public GradeHttpClient HttpClient { get; }
        public GlobalState State { get; }

        public Locator GetLocator()
        {
            int? cYear = null;
            if (CYearIndex > 0 && CYearIndex < CYears.Count)
            {
                cYear = CYears[CYearIndex];
            }
            int? year = null;
            if (YearIndex > 0 && YearIndex < Years.Count)
            {
                year = Years[YearIndex];
            }
            int modeIndex = ModeIndex;
            if (modeIndex < 0 || modeIndex >= Modes.Count)
            {
                modeIndex = 0;
            }
            LocatorMode mode = Modes[modeIndex];
            if (mode == LocatorMode.Struct)
            {
                if (ProfessionIndex <= 0)
                {
                    return Locator.All(cYear, year);
                }
                else
                {
                    var profession = Professions[ProfessionIndex];
                    if (ClassIndex <= 0)
                    {
                        return Locator.Profession(profession.Pno, cYear, year);
                    }
                    else
                    {
                        var xclass = Xclasses[ClassIndex];
                        return Locator.Xclass(xclass.Cno, cYear, year);
                    }
                }
            }
            else if (mode == LocatorMode.Dest)
            {
                if (ProvinceIndex <= 0)
                {
                    return Locator.All(cYear, year);
                }
                else
                {
                    var province = Provinces[ProvinceIndex];
                    if (CityIndex <= 0)
                    {
                        return Locator.Province(province.Prno, cYear, year);
                    }
                    else
                    {
                        var city = Cities[CityIndex];
                        return Locator.City(city.Cino, cYear, year);
                    }
                }
            }
            else if (mode == LocatorMode.Teacher)
            {
                if (TeacherIndex <= 0)
                {
                    return Locator.All(cYear, year);
                } 
                else
                {
                    var teacher = Teachers[TeacherIndex];
                    return Locator.Teacher(teacher.Tno, cYear, year);
                }
            }
            else if (mode == LocatorMode.Course)
            {
                if (CourseIndex <= 0)
                {
                    return Locator.All(cYear, year);
                }
                else
                {
                    var course = Courses[CourseIndex];
                    return Locator.Course(course.Cono, cYear, year);
                }
            }
            return Locator.All();
        }

        private void OnUpdateXclass()
        {


            if (ProfessionIndex <= 0 || ProfessionIndex >= Professions.Count)
            {
                Xclasses.ReplaceItems(new[] { FrameWork.Dto.Xclass.All });
                ClassIndex = 0;
            }
            else
            {
                var classIndex = ClassIndex;
                // Xclasses.Clear();
                var cyear = CYears[CYearIndex];
                Xclasses.ReplaceItems(from item in Professions[ProfessionIndex].Xclasses where cyear <= 0 || cyear == item.Year select item);
                Xclasses.Insert(0, FrameWork.Dto.Xclass.All);
                //foreach (var item in StudentStruct[ProfessionIndex].Xclasses)
                //{
                //    Xclasses.Add(item);
                //}
                if (classIndex < Xclasses.Count)
                {
                    ClassIndex = classIndex;
                }
                else
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
                }
                else
                {
                    CityIndex = 0;
                }
            }
        }

        private void OnSelectModeChanged()
        {
            if (SelectorMode == SelectorMode.StructDest)
            {
                Modes.ReplaceItems(new[] { LocatorMode.Struct, LocatorMode.Dest });
            }
            else if (SelectorMode == SelectorMode.StructOnly)
            {
                Modes.ReplaceItems(new[] { LocatorMode.Struct });
            } else if(SelectorMode == SelectorMode.DestOnly)
            {
                Modes.ReplaceItems(new[] { LocatorMode.Dest });
            } else if(SelectorMode == SelectorMode.StructTeacherCourse)
            {
                Modes.ReplaceItems(new[] { LocatorMode.Struct, LocatorMode.Teacher, LocatorMode.Course });
            }
            ModeIndex = 0;
        }

        private void OnModeIndexChanged()
        {
            int index = ModeIndex;
            if (index >=0 && index < Modes.Count)
            {
                var locatorMode = Modes[index];
                Mode = locatorMode;
            }

        }

        public async void FetchStudentStructAsync()
        {
            App.Dispatcher.Invoke(() =>
            {
                IsStudentStructFetchingEnabled = false;
            });

            var studentStruct = await HttpClient.GetStudentStructAsync();
            lock (Professions)
            {
                App.Dispatcher.Invoke(() => {
                    if (studentStruct == null)
                    {
                        State.Message = "加载错误";
                    }
                    else
                    {
                        int index = ProfessionIndex;
                        Professions.ReplaceItems(studentStruct);
                        Professions.Insert(0, FrameWork.Dto.Profession.All);
                        if (index >= 0 && index < Professions.Count)
                        {
                            ProfessionIndex = index;
                        }
                        else
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
        public async void FetchDestStructAsync()
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
                        State.Message = "加载错误";
                    }
                    else
                    {
                        int index = ProvinceIndex;
                        Provinces.ReplaceItems(provinces);
                        Provinces.Insert(0, FrameWork.Dto.Province.All);
                        if (index >= 0 && index < Provinces.Count)
                        {
                            ProvinceIndex = index;
                        }
                        else
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
        public async void FetchYearsAsync()
        {
            App.Dispatcher.Invoke(() =>
            {
                IsYearsFetchEnabled = false;
            });

            var terms = await HttpClient.GetTermsAsync();

            lock (Years)
            {
                App.Dispatcher.Invoke(() =>
                {
                    var index = YearIndex;
                    HashSet<int> sets = new HashSet<int>();
                    sets.Add(-1);
                    foreach (var item in terms)
                    {
                        sets.Add(item.Year);
                    }


                    Years.ReplaceItems(sets.OrderBy(item => item));


                    if (index > 0 && index < Years.Count)
                    {
                        YearIndex = index;
                    }
                    else
                    {
                        YearIndex = 0;
                    }
                });
            }


            App.Dispatcher.Invoke(() =>
            {
                IsYearsFetchEnabled = true;
            });
        }
        public async void FetchTeachersAsync()
        {
            App.Dispatcher.Invoke(() => IsTeacherFetchEnabled = false);
            var teachers = await HttpClient.GetTeachersAsync();
            lock (Teachers)
            {
                App.Dispatcher.Invoke(() =>
                {
                    if (teachers == null)
                    {
                        State.Message = "加载错误";
                    }
                    var teacherIndex = TeacherIndex;
                    Teachers.ReplaceItems(teachers);
                    Teachers.Insert(0, Teacher.All);
                    if (teacherIndex > 0 && teacherIndex < Teachers.Count)
                    {
                        TeacherIndex = teacherIndex;
                    } else
                    {
                        TeacherIndex = 0;
                    }
                });
            }


            App.Dispatcher.Invoke(() => IsTeacherFetchEnabled = true);
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
                    var courseIndex = CourseIndex;
                    Courses.ReplaceItems(courses);
                    Courses.Insert(0, Course.All);
                    if (courseIndex > 0 && courseIndex < Courses.Count)
                    {
                        CourseIndex = courseIndex;
                    }
                    else
                    {
                        CourseIndex = 0;
                    }
                });
            }


            App.Dispatcher.Invoke(() => IsCourseFetchEnabled = true);
        }

        public async void FetchStudentAsync()
        {
            App.Dispatcher.Invoke(() => IsStudentFetchEnabled = false);

            if (ClassIndex > 0 && ClassIndex < Xclasses.Count)
            {
                var students = await HttpClient.GetStudentsAsync(Scope.Xclass, Xclasses[ClassIndex].Cno.ToString());
                lock (Students)
                {
                    App.Dispatcher.Invoke(() =>
                    {
                        if (students == null)
                        {
                            State.Message = "加载错误";
                        }
                        var studentIndex = StudentIndex;
                        Students.ReplaceItems(students);
                        Students.Insert(0, StudentOut.All);
                        if (studentIndex > 0 && studentIndex < Students.Count)
                        {
                            StudentIndex = studentIndex;
                        }
                        else
                        {
                            StudentIndex = 0;
                        }
                    });
                }
            }
            
            

            App.Dispatcher.Invoke(() => IsStudentFetchEnabled = true);
        }

        public void FetchData()
        {
            FetchStudentStructAsync();
            FetchDestStructAsync();
            FetchYearsAsync();
            FetchTeachersAsync();
            FetchCoursesAsync();
            FetchStudentAsync();
        }

        public static readonly DependencyProperty ProfessionsProperty =
            DependencyProperty.Register(nameof(Professions),
        typeof(ReplaceCollection<FrameWork.Dto.Profession>),
        typeof(SelectorViewModel),
        new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.Profession>((left, right) => left.Pno.CompareTo(right.Pno)) {
                    FrameWork.Dto.Profession.All
        }));

        public static readonly DependencyProperty XclassesProperty =
            DependencyProperty.Register(nameof(Xclasses),
                typeof(ReplaceCollection<FrameWork.Dto.Xclass>),
                typeof(SelectorViewModel),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.Xclass>((left, right) => left.Cno.CompareTo(right.Cno)) {
                    FrameWork.Dto.Xclass.All
                }));


        public static readonly DependencyProperty ProvincesProperty =
            DependencyProperty.Register(nameof(Provinces),
                typeof(ReplaceCollection<FrameWork.Dto.Province>),
                typeof(SelectorViewModel),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.Province>((left, right) => left.Prno.CompareTo(right.Prno)) {
                    FrameWork.Dto.Province.All
                }));

        public static readonly DependencyProperty CitiesProperty =
            DependencyProperty.Register(nameof(Cities), typeof(ReplaceCollection<FrameWork.Dto.City>), typeof(SelectorViewModel),
                new PropertyMetadata(new ReplaceCollection<FrameWork.Dto.City>((left, right) => left.Cino.CompareTo(right.Cino)) {
                    FrameWork.Dto.City.All
                }));

        public static readonly DependencyProperty CYearsProperty =
            DependencyProperty.Register(nameof(CYears), typeof(ReplaceCollection<int>), typeof(SelectorViewModel), new PropertyMetadata(new ReplaceCollection<int>() { -1 }));


        public static readonly DependencyProperty CoursesProperty =
            DependencyProperty.Register(nameof(Courses), typeof(ReplaceCollection<Course>), typeof(SelectorViewModel), new PropertyMetadata(new ReplaceCollection<Course>() { Course.All }));

        public static readonly DependencyProperty TeachersProperty =
            DependencyProperty.Register(nameof(Teachers), typeof(ReplaceCollection<Teacher>), typeof(SelectorViewModel), new PropertyMetadata(new ReplaceCollection<Teacher>() { Teacher.All }));

        public ReplaceCollection<LocatorMode> Modes
        {
            get { return (ReplaceCollection<LocatorMode>)GetValue(ModesProperty); }
            set { SetValue(ModesProperty, value); }
        }

        public static readonly DependencyProperty ModesProperty =
            DependencyProperty.Register(nameof(Modes), typeof(ReplaceCollection<LocatorMode>), typeof(SelectorViewModel), new PropertyMetadata(new ReplaceCollection<LocatorMode>() {
                LocatorMode.Struct,
                LocatorMode.Dest
            }));

        public static readonly DependencyProperty YearsProperty =
            DependencyProperty.Register(nameof(Years), typeof(ReplaceCollection<int>), typeof(SelectorViewModel), new PropertyMetadata(
                new ReplaceCollection<int>(){-1}));

        public static readonly DependencyProperty ModeIndexProperty =
            DependencyProperty.Register(nameof(ModeIndex), typeof(int), typeof(SelectorViewModel), new PropertyMetadata(0
                ,(d,e)=> {
                    ((SelectorViewModel)d).OnModeIndexChanged();
                }));

        public static readonly DependencyProperty CYearIndexProperty =
            DependencyProperty.Register(nameof(CYearIndex), typeof(int), typeof(SelectorViewModel),
                new PropertyMetadata(0, (d, e) => {
                    var dobj = (SelectorViewModel)d;
                    dobj.OnUpdateXclass();
                }));

        public static readonly DependencyProperty YearIndexProperty =
            DependencyProperty.Register(nameof(YearIndex), typeof(int), typeof(SelectorViewModel), new PropertyMetadata(0));

        public static readonly DependencyProperty ProfessionIndexProperty =
            DependencyProperty.Register(nameof(ProfessionIndex), typeof(int), typeof(SelectorViewModel),
                new PropertyMetadata(0, (d, e) => {
                    var dobj = (SelectorViewModel)d;
                    dobj.OnUpdateXclass();
                }));

        public static readonly DependencyProperty ClassIndexProperty =
            DependencyProperty.Register(nameof(ClassIndex), typeof(int), typeof(SelectorViewModel),
                new PropertyMetadata(0, (d,e) => {
                    var dobj = (SelectorViewModel)d;
                    dobj.FetchStudentAsync();
                }));

        public static readonly DependencyProperty ProvinceIndexProperty =
            DependencyProperty.Register(nameof(ProvinceIndex), typeof(int), typeof(SelectorViewModel),
                new PropertyMetadata(0, (d, e) => {
                    var dobj = (SelectorViewModel)d;
                    dobj.OnUpdateCities();
                }));

        public static readonly DependencyProperty CityIndexProperty =
            DependencyProperty.Register(nameof(CityIndex), typeof(int), typeof(SelectorViewModel), new PropertyMetadata(0));

        public static readonly DependencyProperty CourseIndexProperty =
            DependencyProperty.Register(nameof(CourseIndex), typeof(int), typeof(SelectorViewModel), new PropertyMetadata(0));

        public static readonly DependencyProperty TeacherIndexProperty =
            DependencyProperty.Register(nameof(TeacherIndex), typeof(int), typeof(SelectorViewModel), new PropertyMetadata(0));

        public static readonly DependencyProperty StudentIndexProperty =
            DependencyProperty.Register(nameof(StudentIndex), typeof(int), typeof(SelectorViewModel), new PropertyMetadata(0));

        public static readonly DependencyProperty IsStudentStructFetchingEnabledProperty =
            DependencyProperty.Register(nameof(IsStudentStructFetchingEnabled), typeof(bool), typeof(SelectorViewModel), new PropertyMetadata(true));

        public static readonly DependencyProperty IsDestStructFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsDestStructFetchEnabled), typeof(bool), typeof(SelectorViewModel), new PropertyMetadata(true));

        public static readonly DependencyProperty IsYearsFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsYearsFetchEnabled), typeof(bool), typeof(SelectorViewModel), new PropertyMetadata(true));

        public static readonly DependencyProperty SelectorModeProperty =
            DependencyProperty.Register(nameof(SelectorMode), typeof(SelectorMode), typeof(SelectorViewModel), new PropertyMetadata(SelectorMode.StructDest, 
                (d,e) => {
                    ((SelectorViewModel)d).OnSelectModeChanged();
                }));

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register(nameof(Mode), typeof(LocatorMode), typeof(SelectorViewModel), new PropertyMetadata(LocatorMode.Struct));


        public static readonly DependencyProperty IsTeacherFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsTeacherFetchEnabled), typeof(bool), typeof(SelectorViewModel), new PropertyMetadata(true));

        public static readonly DependencyProperty IsCourseFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsCourseFetchEnabled), typeof(bool), typeof(SelectorViewModel), new PropertyMetadata(true));

        public static readonly DependencyProperty IsStudentFetchEnabledProperty =
            DependencyProperty.Register(nameof(IsStudentFetchEnabled), typeof(bool), typeof(SelectorViewModel), new PropertyMetadata(true));

        public static readonly DependencyProperty StudentsProperty =
            DependencyProperty.Register(nameof(Students), typeof(ReplaceCollection<StudentOut>), typeof(SelectorViewModel), new PropertyMetadata(new ReplaceCollection<StudentOut>() { StudentOut.All}));
    }
}
