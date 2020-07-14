# 应用系统开发

## 界面的设计

### 地区概览页面(route:page/dest_summary)

- 查看地区基本信息以及统计信息

### 班级概览界面(route:page/class_summary)

- 查看班级基本信息以及统计信息

### 学生管理界面(route:page/students)

- 查看学生的基本信息
    - 列：学号(Sno)、姓名(Name)、年龄(Age)、专业(PName)、届数(Year)、班级(CName)、省(Province)、市(City)、总学分(TotalCredit)、已修学分(CompletedCredit)、总绩点和(Point)。
    - 筛选：专业、班级、省、市；届数
    - 引用api：struct,dest_struct,students
    
> 备注：总学分是指已经有报告的学分和（无论成绩有没有及格），已修学分指已经有报告且及格的学分和。总绩点和指（sum{(单科成绩-50)/10*单科的绩点}）

### 学生详情界面(route:page/students/{id:string})

### 班级管理界面(route:page/teachers)


### 成绩详细界面(route:page/reports)

- 查看成绩的基本信息
    - 列：学号(Sno)、姓名(Name)、年龄(Age)、专业(PName)、届数(CYear)、班级名(CName)、课程名(CoName)、开课时间(Year)、开课学期(Term)、授课教师(TName)、成绩(Grade)、学分(Credit)、获得的学分(CreditGet)
    - 筛选：专业、班级；届数；开课时间
    - 引用api: struct,reports

### 成绩统计界面(route:page/report_summary)

- 查看学生的统计信息
    - 列：学号(Sno)、姓名(Name)、年龄(Age)、专业(PName)、届数(CYear)、开课时间(Year)、班级名(CName)、总体成绩及排名(TotalGrade)、每年的成绩和排名(Grades)
    - 筛选：专业、班级；届数；开课时间
    - 引用api: report_summary

### 课程统计界面

- 查看课程的统计信息
    - 列：课程号(Cono)、课程名(CoName)、专业(PName)、届数(CYear)、班级(CName)、开课教师(TName)、平均成绩(Avg_Grade)。
    - 筛选：专业、班级、课程、任课教师；届数；开课时间
    引用api: course_summary

### 开课统计界面

TODO: 待完善

- 查看班级的课表信息
    - 列: 
    - 引用api: course_summary

### 教师任课界面

TODO: 待完善

- 查看教师的任课信息
    - 列：
    - 引用api: course_summary

## 对应的api及其说明

#### 查看地区概览信息(api/dest_summary)

api/dest_summary?[scope=all|province|city]&[tag=?]&[year=?]

```json
[
    {
        "prno": 1,
        "prName": "浙江省",
        "prSummaryCount": 7,
        "cino": 1,
        "ciName": "杭州市",
        "ciSummaryCount": 6
    },
    {
        "prno": 1,
        "prName": "浙江省",
        "prSummaryCount": 7,
        "cino": 2,
        "ciName": "宁波市",
        "ciSummaryCount": 0
    }
]
```

#### 查看班级概览信息(api/class_summary)

api/class_summary?[scope=all|profession|class]&[tag=?]&[year=?]

```json
[
    {
        "pno": 1,
        "pName": "实验班",
        "pSummaryCount": 9,
        "cno": 1,
        "cYear": 2016,
        "cName": "1班",
        "cSummaryCount": 8,
        "cDisplay": "2016届1班"
    },
    {
        "pno": 1,
        "pName": "实验班",
        "pSummaryCount": 9,
        "cno": 2,
        "cYear": 2017,
        "cName": "1班",
        "cSummaryCount": 1,
        "cDisplay": "2017届1班"
    }
]
```

#### 查看结构信息(api/struct)

 api/struct

```json
[
    {
        "pno": 1,
        "name": "实验班",
        "xclasses": [
            {
                "cno": 1,
                "name": "1班",
                "year": 2016
            },
            {
                "cno": 2,
                "name": "1班",
                "year": 2017
            },
            {
                "cno": 3,
                "name": "1班",
                "year": 2018
            }
        ]
    }
]
```

#### 查看地区结构信息(api/dest_struct)

api/dest_struct

```json
[
    {
        "prno": 1,
        "name": "浙江省",
        "cities": [
            {
                "cino": 1,
                "name": "杭州市"
            },
            {
                "cino": 2,
                "name": "宁波市"
            },
            {
                "cino": 3,
                "name": "温州市"
            }
        ]
    }
]
```

#### 查看学生信息(api/students)

api/students?[scope=all|profession|class|province|city]&[tag=?]&[year=?]

```json
[
    {
        "sno": "S000002",
        "name": "学生2",
        "sex": 1,
        "age": 17,
        "cno": 1,
        "cYear": 2016,
        "cName": "1班",
        "cDisplay": "2016届1班",
        "pno": 1,
        "pName": "实验班",
        "prno": 1,
        "prName": "浙江省",
        "cino": 1,
        "ciName": "杭州市",
        "totalCredit": 3,
        "completeCredit": 3,
        "point": 11.1,
        "gpa": 3.6999999999999997,
        "order": 1
    }
]
```

#### 查看教师信息(api/teachers)

api/teachers

```json
[
    {
        "tno": "T000001",
        "name": "教师1",
        "sex": 0,
        "age": 34,
        "level": 0,
        "phone": "13000000000"
    },
    {
        "tno": "T000002",
        "name": "教师2",
        "sex": 0,
        "age": 34,
        "level": 0,
        "phone": "13000000000"
    },
    {
        "tno": "T000003",
        "name": "教师3",
        "sex": 0,
        "age": 34,
        "level": 0,
        "phone": "13000000000"
    },
    {
        "tno": "T000004",
        "name": "教师4",
        "sex": 0,
        "age": 34,
        "level": 0,
        "phone": "13000000000"
    },
    {
        "tno": "T000005",
        "name": "教师5",
        "sex": 0,
        "age": 34,
        "level": 0,
        "phone": "13000000000"
    }
]
```

#### 查看成绩详细信息(api/report)

api/report?[scope=all|profession|class|province|city|opencourse|course|student|teacher]&[tag=?]&[year=?]&[cyear=?]

```json
[
    {
        "sno": "S000002",
        "sName": "学生2",
        "sSex": 1,
        "sAge": 17,
        "grade": 87,
        "cno": 1,
        "cYear": 2016,
        "cName": "1班",
        "pno": 1,
        "pName": "实验班",
        "prno": 1,
        "prName": "浙江省",
        "cino": 1,
        "ciName": "杭州市",
        "ono": 1,
        "cono": 1,
        "coName": "计算机组成原理",
        "credit": 3,
        "creditGet": 3,
        "period": 48,
        "way": 0,
        "year": 2020,
        "term": 0,
        "tno": "T000001",
        "tName": "教师1",
        "tAge": 34,
        "tsex": 0,
        "level": 0,
        "phone": "13000000000"
    }
]
```

#### 查看成绩统计信息(api/report_summary)

api/report_summary?[scope=all|profession|class]&[tag=?]&[year=?]&[cyear=?]

```json
[
    {
        "sno": "S000002",
        "name": "学生2",
        "sex": 1,
        "age": 17,
        "cno": 1,
        "cYear": 2016,
        "cName": "1班",
        "pno": 1,
        "pName": "实验班",
        "totalGrade": {
            "year": null,
            "totalCredit": 3,
            "completeCredit": 3,
            "gpa": 3.6999999999999997,
            "point": 11.1,
            "orderOfSchool": 1,
            "orderOfProfession": 1,
            "orderOfClass": 1
        },
        "grades": [
            {
                "year": 2020,
                "totalCredit": 3,
                "completeCredit": 3,
                "gpa": 3.6999999999999997,
                "point": 11.1,
                "orderOfSchool": 1,
                "orderOfProfession": 1,
                "orderOfClass": 1
            }
        ]
    }
]
```

#### 查看课程统计信息(api/course_summary)

api/course_summary?[scope=all|profession|class|teacher|course]&[tag=?]&[year=?]&[cyear=?]

```json
[
    {
        "ono": 1,
        "cono": 1,
        "coName": "计算机组成原理",
        "credit": 3,
        "period": 48,
        "way": 0,
        "year": 2020,
        "term": 0,
        "cno": 1,
        "cName": "1班",
        "cYear": 2016,
        "pno": 1,
        "pName": "实验班",
        "tno": "T000001",
        "tName": "教师1",
        "tAge": 34,
        "tSex": 0,
        "tLevel": 0,
        "tPhone": "13000000000",
        "avgGrade": 87,
        "orderOfSchool": 1,
        "orderOfProfession": 1,
        "orderOfClass": 1
    }
]
```

#### 查看学期(api/terms)

api/terms

```json
[
    {
        "year": 2020,
        "term": 0
    },
    {
        "year": 2020,
        "term": 1
    }
]
```

#### 查看开课信息(api/open_courses)

api/open_courses?[scope=profession|class|course|teacher]&[tag=?]&[year=?]&[cyear=?]

```json
[
    {
        "ono": 1,
        "cono": 1,
        "coName": "计算机组成原理",
        "credit": 3,
        "period": 48,
        "way": 0,
        "year": 2020,
        "term": 0,
        "cno": 1,
        "cName": "1班",
        "cYear": 2016,
        "pno": 1,
        "pName": "实验班",
        "tno": "T000001",
        "tName": "教师1",
        "tAge": 34,
        "tSex": 0,
        "tLevel": 0,
        "tPhone": "13000000000"
    }
]
```