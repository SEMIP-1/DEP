--use iti database
use  iti
go

--1.	Retrieve a number of students who have a value in their age. 
select COUNT(st_id)
from Student 
where St_Age is not null
go

--2.	Display number of courses for each topic name 
select Top_Name,COUNT(Crs_Name)
from Course c,Topic t
where C.Top_Id=t.Top_Id
group by t.Top_Name
go

--3.	Select Student first name and the data of his supervisor 
select s.St_Fname , sup.* from Student s
left join Student sup
on s.St_super = sup.St_Id
go

--4.	Display student with the following Format (use isNull function)
--Student ID	Student Full Name	Department name
select s.st_id as [Student ID] , (s.St_Fname + ' ' + s.St_Lname) as [Student Full Name] , isNull (d.Dept_Name , 'No Department') as [Department name]
from Student s left join Department d
on d.Dept_Id = s.Dept_Id
go

--5.	Select instructor name and his salary but if there is no salary display value ‘0000’. “Use one of Null Function” 
select Ins_Name , ISNULL (Salary , '0000') as Salary
from Instructor
go

--6.	Select Supervisor first name and the count of students who supervises on them
select Super.St_Fname as [Supervisor Name] , count (S.St_id) as [Supuervises]
from Student Super join Student s
on s.St_super = Super.St_Id
group by Super.St_Fname
go

--7.	Display max and min salary for instructors
select Min(Salary) as [Minimum Salary] , Max(Salary) as [Maximum Salary]
from Instructor
go

--8.	Select Average Salary for instructors 
select Avg(Salary) as [Average Salary]
from Instructor
go

--9.	Display instructors who have salaries less than the average salary of all instructors.
select i.Ins_Name from Instructor i where i.Salary < (select AVG(Salary) from Instructor)
go

--10.	Display the Department name that contains the instructor who receives the minimum salary
select d.Dept_Name
from Department d join Instructor i
on i.Dept_Id = d.Dept_Id
where i.Salary = (select min (Salary) from Instructor)
go

select 
IIF(count(*)<300,N'العدد قليل',cast(avg(salary) as varchar)) as[ Result]
from instructor