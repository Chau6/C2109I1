﻿use master
go

drop database if exists CSharp_Window_Form
create database CSharp_Window_Form
go

use CSharp_Window_Form
go

drop table if exists Student
create table Student
(
	ID int primary key identity,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Gender bit,--bit là nam/nữ, char(1) hoặc tinyint dùng cho giới tính có "khác"
	Dob date
)
go

insert into Student(FirstName, LastName, Gender, Dob) values (N'Trương', N'Châu','true','2003/02/06') --kiểu date lúc insert phải là yyyy/mm/dd
go 10