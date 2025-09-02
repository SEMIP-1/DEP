--Part 01 (Views)
Use ITI
--------------------------------------------
--1.	 Create a view that displays the student's full name, course name if the student has a grade more than 50. 
create view v_student_courses 
as
select 
    s.st_fname + ' ' + s.st_lname as fullname,
    c.crs_name as coursename
from student s
join stud_course sc on s.st_id = sc.st_id
join course c on sc.crs_id = c.crs_id
where sc.grade > 50;
go
select * 
from v_student_courses
go

--2.	 Create an Encrypted view that displays manager names and the topics they teach. 
---??????

--3.	Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department “use Schema binding” and describe what is the meaning of Schema Binding
create view v_instructor_dept
with schemabinding
as
select 
    i.ins_name,
    d.dept_name
from dbo.instructor i
join dbo.department d on i.dept_id = d.dept_id
where d.dept_name in ('sd', 'java');
go
select * 
from v_instructor_dept
go

--4.	 Create a view “V1” that displays student data for students who live in Alex or Cairo. 
create view v1
as
select *
from student
where st_address in ('alex', 'cairo')
with check option;
go
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;
update v1
set st_address = 'tanta'
where st_address = 'alex';
-----------------------------------------------------------------
use MyCompany
--0.	Create a view that will display the project name and the number of employees working on it. (Use Company DB)
create view v_project_employee_count
as
select 
    p.pname as projectname,
    count(e.ssn) as employeecount
from project p
join works_for wf on p.pnumber = wf.pno
join employee e on wf.essn = e.ssn
group by p.pname;
go
select *
from v_project_employee_count
go
------------------------------------------------------------------------
use IKEA_Company
--1.	Create a view named “v_clerk” that will display employee Number, project Number, the date of hiring of all the jobs of the type 'Clerk'.
create view v_clerk as
select 
    e.empno,
    w.projectno,
    w.enter_date
from hr.Employee e
join Works_on w on e.empno = w.empno
where w.job = 'clerk';
go
select *
from v_clerk
go
--2.	 Create view named  “v_without_budget” that will display all the projects data without budget
create view v_without_budget as
select *
from hr.Project
where budget is null;
go
select *
from v_without_budget
go

--3.	Create view named  “v_count “ that will display the project name and the Number of jobs in it

--4.	 Create a view named” v_project_p2” that will display the emp# s for the project# ‘p2’. (use the previously created view  “v_clerk”)
--5.	modify the view named “v_without_budget” to display all DATA in project p1 and p2.
--6.	Delete the views  “v_ clerk” and “v_count”
--7.	Create view that will display the emp# and emp last name who works on deptNumber is ‘d2’
--8.	Display the employee  lastname that contains letter “J” (Use the previous view created in Q#7)
--9.	Create view named “v_dept” that will display the department# and department name
--10.	using the previous view try enter new department data where dept# is ’d4’ and dept name is ‘Development’
--11.	Create view name “v_2006_check” that will display employee Number, 
--the project Number where he works and the date of joining the project which must be from the first of January and the last of December 2006.
--this view will be used to insert data so make sure that the coming new data must match the condition


----------------------



