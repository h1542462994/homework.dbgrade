# 逻辑结构设计

## 视图

### 基本流式视图

#### 视图1 StudentsView : Students, Xclasses, Professions, Cities, Provinces

通过连接操作补全学生的基本信息，班级信息，专业信息，地区信息。

#### 视图2 OpenCoursesView

通过连接操作补全OpenCourses的基本信息，学期开设信息，课程信息，教师信息

#### 视图3 ReportsView : StudentsView, OpenCoursesView

### 统计流式视图

#### 视图1 DestSummaryView : Provinces, Cities

地区统计视图

#### 视图2 XclassSummaryView: Xclass, Students

班级统计视图

#### 视图3 ProvinceSummaryView: Provinces, XclassSummaryView

### 高级统计视图

### paging

#### 查看结构信息

 api/struct?[year=?]

```json
[
    {
        "pno": 1,
        "name": "实验班",
        "xclasses": [
            {
                "studentCount": 8,
                "cno": 1,
                "name": "1班",
                "year": 2016
            },
            {
                "studentCount": 1,
                "cno": 2,
                "name": "1班",
                "year": 2017
            },
            {
                "studentCount": 0,
                "cno": 3,
                "name": "1班",
                "year": 2018
            }
        ]
    }
]
```

#### 查看地区结构信息

api/dest_struct?[year=?]

```json
[
    {
        "prno": 1,
        "name": "浙江省",
        "cities": [
            {
                "cino": 1,
                "name": "杭州市",
                "studentCount": 6
            },
            {
                "cino": 2,
                "name": "宁波市",
                "studentCount": 0
            },
            {
                "cino": 3,
                "name": "温州市",
                "studentCount": 0
            },
            {
                "cino": 4,
                "name": "嘉兴市",
                "studentCount": 0
            }
        ]
    }
]
```

#### 查看学生信息

api/students?[scope=all|profession|class|province|city]&[tag=?]&[year=?]

```json
[
    {
        "sno": "S000001",
        "name": "学生1",
        "sex": 0,
        "age": 18,
        "cno": 2,
        "cYear": 2017,
        "cName": "1班",
        "pno": 1,
        "pName": "实验班",
        "prno": 1,
        "prName": "浙江省",
        "cino": 12,
        "ciName": "舟山群岛新区",
        "totalCredit": 0
    }
]
```

#### 查看成绩统计信息

api/report?[scope=all|profession|class|province|city|opencourse|course|student|teacher]&[tag=?]&[year=?]&[cyear=?]

```json
[
    {
        "sno": "S000002",
        "sName": "学生2",
        "sSex": 1,
        "sAge": 17,
        "grade": 87,
        "totalCredit": 3,
        "cno": 1,
        "cYear": 2016,
        "cName": "学生2",
        "pno": 1,
        "pName": "实验班",
        "prno": 1,
        "prName": "浙江省",
        "cino": 1,
        "ciName": "杭州市",
        "ono": 1,
        "cono": 1,
        "coName": "计算机组成原理",
        "credit": 0,
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

### 主要功能

1. 查看地区统计信息
2. 查看专业、班级统计信息
3. 查看学生信息（可以按照地区或者专业、班级过滤，年份）
4. 查看成绩统计信息（可以按照地区、专业、班级、课程、开课过滤、年份、学生学号、教师学号过滤）