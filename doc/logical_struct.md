# 逻辑结构设计

## 基本表

> 基本表的设计请看对应的sql语句

仅对需要的格式规范做出说明。

## 视图

## 触发器

## 存储过程

### 基本流式视图

#### 视图1 StudentsView : Students, Xclasses, Professions, Cities, Provinces

通过连接操作补全学生的基本信息，班级信息，专业信息，地区信息。

#### 视图2 OpenCoursesView

通过连接操作补全OpenCourses的基本信息，学期开设信息，课程信息，教师信息

#### 视图3 ReportsView : StudentsView, OpenCoursesView

通过连接视图补全Reports的基本信息，以及开课，课程、班级、学生信息。

### 统计流式视图

#### 视图1 DestSummaryView : Provinces, Cities

*此视图仅用于查看信息所用，并不在程序中使用。*

地区统计视图

#### 视图2 XclassSummaryView: Xclass, Students

*此视图仅用于查看信息所用，并不在程序中使用。*

班级统计视图（统计人数）

#### 视图3 ProfessionSummaryView: Profession, Students

*此视图仅用于查看信息所用，并不在程序中使用。*

专业统计视图（统计人数）

#### 视图4 StructView: Profession, Xclasses, XclassSummaryView, ProfessionSummaryView

*此视图仅用于查看信息所用，并不在程序中使用。*

专业、班级统计视图

### 高级统计视图



### 主要功能

1. 查看地区统计信息
2. 查看专业、班级统计信息
3. 查看学生信息（可以按照地区或者专业、班级过滤，年份）
4. 查看成绩统计信息（可以按照地区、专业、班级、课程、开课过滤、年份、学生学号、教师学号过滤）