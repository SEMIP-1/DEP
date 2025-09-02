--Part 02

--1.Create a stored procedure to show the number of students per department.[use ITI DB] 
use iti;
go

create procedure sp_students_per_department
as
begin
    select 
        d.Dept_Name,
        count(s.st_id) as student_count
    from department d
    left join student s on d.dept_id = s.dept_id
    group by d.Dept_Name;
end;
go
--2.Create a stored procedure that will check for the Number of employees in the project 100 if they are more than 3 print message to the user 
--“'The number of employees in the project 100 is 3 or more'” if they are less display a message to the user “'The following employees work for the project 100'” 
--in addition to the first name and last name of each one. [MyCompany DB] 
use mycompany;
go

create procedure sp_check_project_100
as
begin
    declare @emp_count int;

    select @emp_count = count(e.SSN)
    from employee e
    join works_for w on e.SSN = w.ESSn
    where w.pno = 100;

    if @emp_count >= 3
    begin
        print 'the number of employees in the project 100 is 3 or more';
    end
    else
    begin
        print 'the following employees work for the project 100';

        select e.fname, e.lname
        from employee e
        join works_for w on e.SSN = w.ESSn
        where w.pno = 100;
    end
end;
go

--3.Create a stored procedure that will be used in case an old employee has left the project and a new one becomes his replacement. 
--The procedure should take 3 parameters (old Emp. number, new Emp. number and the project number) and it will be used to update works_on table. [MyCompany DB]
create procedure sp_replace_employee
    @old_empno int,
    @new_empno int,
    @projno int
as
begin
    update works_for
    set ESSn = @new_empno
    where ESSn = @old_empno
    and pno = @projno;
end;
go