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