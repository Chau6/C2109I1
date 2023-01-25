USE MASTER
GO

DROP DATABASE IF EXISTS Exam_CSharp
CREATE DATABASE Exam_CSharp
GO

USE Exam_CSharp
GO

--xóa nhiều -> 1
DROP TABLE IF EXISTS tblExam
CREATE TABLE tblExam
(
	examId TINYINT PRIMARY KEY IDENTITY,
	examName NVARCHAR(100),
	examMark FLOAT, --điểm
	examDate DATE,
	stuId TINYINT,
	couId TINYINT,
	createAt DATETIME,
	updateAt DATETIME
)
GO

INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
VALUES (N'KT HKI',4,'2023-01-20',3,1,GETDATE())
INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
VALUES (N'KT HKI',5,'2023-01-20',4,2,GETDATE())
INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
VALUES (N'KT HKI',6,'2023-01-20',5,3,GETDATE())
INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
VALUES (N'KT HKI',7,'2023-01-20',6,4,GETDATE())
INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
VALUES (N'KT HKI',8,'2023-01-20',7,5,GETDATE())
INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
VALUES (N'KT HKI',9,'2023-01-20',8,6,GETDATE())
INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
VALUES (N'KT HKI',10,'2023-01-20',9,7,GETDATE())
INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
VALUES (N'KT HKI',10,'2023-01-20',10,8,GETDATE())
GO
--select * from tblExam
--FLOOR(RAND()*11): từ 0 > 10
--FLOOR(RAND()*10+1): từ 1 > 10
--INSERT INTO tblExam(examName,examMark,examDate,stuId,couId,createAt)
--VALUES (N'KT HKI',FLOOR(RAND()*10+1),'2023-01-20',FLOOR(RAND()*10+1),1,GETDATE())
--GO 5
DROP TABLE IF EXISTS tblCourse --khóa học
CREATE TABLE tblCourse
(
	couId TINYINT PRIMARY KEY IDENTITY,
	couName NVARCHAR(100),
	couSemester TINYINT, --học kỳ
)
GO
INSERT INTO tblCourse(couName,couSemester)
VALUES (N'ADSE',1)
GO 8

--select * from tblCourse

DROP TABLE IF EXISTS tblStudent
CREATE TABLE tblStudent
(
	stuId TINYINT PRIMARY KEY IDENTITY,
	stuUsername VARCHAR(50),
	stuPass VARCHAR(50), --change pass
	stuName NVARCHAR(50),
	stuDob DATE, --add
	stuGender BIT,
	stuAddress NVARCHAR(1000),
	stuPhone VARCHAR(15),
	stuEmail VARCHAR(200),
	stuLevel TINYINT, -- 1=Admin 2=GV 3=HS
	deptId TINYINT, --độ sâu ???
	createAt DATETIME,
	updateAt DATETIME
);
GO
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('admin','admin',N'Tấn Châu Admin','2003/02/06',1,N'TPHCM','0386744102','tanchau0602@gmail.com',1,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('teacher','teacher',N'Tấn Châu teacher','2003/02/06',0,N'TPHCM','0386744102','tanchau0603@gmail.com',2,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('stu1','stu1',N'Tấn Châu','2003/02/06',1,N'TPHCM','0386744102','tanchau0604@gmail.com',3,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('stu2','stu2',N'Tấn Châu','2003/02/06',0,N'TPHCM','0386744102','tanchau0605@gmail.com',3,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('stu3','stu3',N'Tấn Châu','2003/02/06',1,N'TPHCM','0386744102','tanchau0606@gmail.com',3,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('stu4','stu4',N'Tấn Châu','2003/02/06',0,N'TPHCM','0386744102','tanchau0607@gmail.com',3,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('stu5','stu5',N'Tấn Châu','2003/02/06',1,N'TPHCM','0386744102','tanchau0608@gmail.com',3,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('stu6','stu6',N'Tấn Châu','2003/02/06',0,N'TPHCM','0386744102','tanchau0609@gmail.com',3,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('stu7','stu7',N'Tấn Châu','2003/02/06',1,N'TPHCM','0386744102','tanchau06010@gmail.com',3,9,GETDATE())
INSERT INTO tblStudent(stuUsername,stuPass,stuName,stuDob,stuGender,stuAddress,stuPhone,stuEmail,stuLevel,deptId,createAt)
VALUES ('stu8','stu8',N'Tấn Châu','2003/02/06',0,N'TPHCM','0386744102','tanchau06011@gmail.com',3,9,GETDATE())
GO
--select * from tblStudent
CREATE OR ALTER PROC GetDataStudent
@Username varchar(50)
AS
BEGIN
	select tblStudent.stuId,stuName,stuGender,stuDob,stuAddress,stuPhone,stuEmail,deptId,examName,examMark,examDate,couName,couSemester from tblStudent
	left join tblExam
	on tblStudent.stuId = tblExam.stuId
	left join tblCourse
	on tblCourse.couId = tblExam.couId
	where tblStudent.stuUsername = @Username
	order by tblStudent.stuId
END
GO
--GetDataStudent 'stu2'

CREATE OR ALTER PROC [Login]
@Username varchar(50),@Password varchar(50)
AS
BEGIN
    IF exists (select * from tblStudent where stuUsername = @Username and stuPass = @Password and stuLevel = 1)
        select 1 as code --admin
    else IF exists (select * from tblStudent where stuUsername = @Username and stuPass = @Password and stuLevel = 2)
        select 2 as code --GV
    else IF exists(select * from tblStudent where stuUsername = @Username and stuPass = @Password and stuLevel = 3) 
        select 3 as code --HS
    else select 4 as code --Not exists
END
GO

--[Login] 'stu2', 'stu2'

CREATE OR ALTER PROC CheckAccount
@Username varchar(50),@Password varchar(50)
AS
BEGIN
    IF exists (select * from tblStudent where stuUsername = @Username and stuPass = @Password)
        select 1 as code --exists
    else select 2 as code --Not exists
END
GO
--CheckAccount 'admin', 'admin'

CREATE OR ALTER PROC CheckUpdateUsername
@Username varchar(50)
AS
BEGIN
    IF exists (select stuUsername from tblStudent where stuUsername = @Username)
        select 1 as [check] --tồn tại
    else select 2 as [check] --k tồn tại
END
GO
--CheckUpdateUsername 'admin'

CREATE OR ALTER PROC CheckUpdateEmail
@Email varchar(50)
AS
BEGIN
    IF exists (select stuEmail from tblStudent where stuEmail = @Email)
        select 1 as [check] --tồn tại
    else select 2 as [check] --k tồn tại
END
GO
--CheckUpdateEmail 'tanchau0602@gmail.com'

CREATE OR ALTER PROC CheckLevelForm
@Username varchar(50)
AS
BEGIN
	IF exists (select stuLevel from tblStudent where stuUsername = @Username)
        select stuLevel as [check] from tblStudent where stuUsername = @Username
    else select 0 as [check] --lỗi
END
GO


ALTER TABLE tblExam
ADD CONSTRAINT FK_tbExam_tblStudent
FOREIGN KEY (stuId) 
REFERENCES tblStudent(stuId);
GO

ALTER TABLE tblExam
ADD CONSTRAINT FK_tblExam_tblCourse
FOREIGN KEY (couId) 
REFERENCES tblCourse(couId);
GO

--CheckLevelForm 'stu2'

--test select

--func: thêm xóa sửa select change-pass gmail
--đã thi: checked
--chưa thi: checked
--thi đậu: checked
--thi rớt: checked
--điểm cao nhất: checked
--điểm thấp nhất: checked
--tìm số học sinh có điểm số lớn nhất thứ n: checked
--tìm số học sinh có điểm số bé nhất thứ n: checked
--xếp loại: giỏi - khá - tb - yếu - kém: checked
--lọc HS theo khóa học: checked
--tìm tổng số sinh viên: checked
--tìm tổng xếp loại giỏi - khá - tb - yếu - kém - chưa thi: checked

----đổ hết ra HS đã thi
--select tblStudent.stuId,tblStudent.stuName,tblExam.examMark from tblStudent
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--where tblStudent.stuId = tblExam.stuId
--order by tblStudent.stuId
----xem HS chưa thi và rớt
--select tblStudent.stuId,tblStudent.stuName,tblExam.examMark from tblStudent 
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--where tblExam.examMark < 4 or tblExam.examMark is null and tblStudent.stuLevel > 2
--order by tblStudent.stuId
----xem HS thi đậu
--select tblStudent.stuId,tblStudent.stuName,tblExam.examMark from tblStudent 
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--where tblExam.examMark >= 4
--order by tblStudent.stuId
----lấy ra toàn bộ HS có số điểm cao nhất
--select tblStudent.stuId,tblStudent.stuName,tblExam.examMark from tblStudent 
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--where tblExam.examMark = (select max(tblExam.examMark) from tblExam)
--order by tblStudent.stuId
----lấy ra toàn bộ HS có số điểm cao thứ 2: not in... = không phải là...
--select tblStudent.stuId,tblStudent.stuName,tblExam.examMark from tblStudent 
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--where tblExam.examMark = (select max(tblExam.examMark) from tblExam where tblExam.examMark not in (select max(tblExam.examMark) from tblExam)) --logic: chọn điểm lớn nhất từ tblExam điều kiện điểm không phải là điểm lớn nhất ở  tblExam 
--order by tblStudent.stuId
----lấy ra toàn bộ HS có số điểm cao thứ 3 = tìm số học sinh có điểm số lớn thứ n
--select stuId,stuName,examMark from (select tblStudent.stuId,tblStudent.stuName,examMark, DENSE_RANK() over(order by tblExam.examMark desc) as R from tblExam
--left join tblStudent
--on tblStudent.stuId = tblExam.stuId) result --result as table
--where result.R=3
----lấy ra toàn bộ HS có số điểm thấp nhất
--select tblStudent.stuId,tblStudent.stuName,tblExam.examMark from tblStudent 
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--where tblExam.examMark = (select min(tblExam.examMark) from tblExam)
--order by tblStudent.stuId
----lấy ra toàn bộ HS có số điểm thấp thứ 2
--select tblStudent.stuId,tblStudent.stuName,tblExam.examMark from tblStudent 
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--where tblExam.examMark = (select min(tblExam.examMark) from tblExam where tblExam.examMark not in (select min(tblExam.examMark) from tblExam))
--order by tblStudent.stuId
----lấy ra toàn bộ HS có số điểm thấp thứ 3 = tìm số học sinh có điểm số bé thứ n
--select stuId,stuName,examMark from (select tblStudent.stuId,tblStudent.stuName,examMark, DENSE_RANK() over(order by tblExam.examMark asc) as R from tblExam
--left join tblStudent
--on tblStudent.stuId = tblExam.stuId) result
--where result.R=3
--order by stuId
----xếp loại
--select stuId,stuName,examMark,couName,couSemester
--,case when examMark >= 9 then N'Giỏi'
--when examMark < 9 and examMark >= 7 then N'Khá'
--when examMark < 7 and examMark >= 5 then N'Trung bình'
--when examMark < 3 then N'Kém'
--when examMark is null then N'Chưa thi'
--else N'Yếu' end as Rating
--from (select tblStudent.stuId,tblStudent.stuName,tblExam.examMark, tblCourse.couName, tblCourse.couSemester from tblStudent
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--left join tblCourse
--on tblExam.couId = tblCourse.couId where tblStudent.stuLevel > 2) result
--order by stuId
----lọc HS theo khóa học
--select tblStudent.stuId,tblStudent.stuName,tblExam.examMark, tblCourse.couName, tblCourse.couSemester from tblStudent
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--left join tblCourse
--on tblExam.couId = tblCourse.couId
--where tblCourse.couName = 'adse'
--order by stuId
----and tblCourse.couSemester = 2
----tìm tổng số sinh viên
--select count(stuId) as Total from tblStudent 
----tìm tổng xếp loại giỏi - khá - tb - yếu - kém
--select *, COUNT(*) as Total from (
--select case when examMark >= 9 then N'Giỏi'
--when examMark < 9 and examMark >= 7 then N'Khá'
--when examMark < 7 and examMark >= 5 then N'Trung bình'
--when examMark < 3 then N'Kém'
--when examMark is null then N'Chưa thi'
--else N'Yếu' end as Rating from (select tblExam.examMark from tblStudent
--left join tblExam
--on tblStudent.stuId = tblExam.stuId
--left join tblCourse
--on tblExam.couId = tblCourse.couId where tblStudent.stuLevel > 2) result) Rating
--group by Rating
--order by Rating desc
----test select