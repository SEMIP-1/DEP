--Part 01
 Use ITI
		
-- 1. Retrieve a number of students who have a value in their age
SELECT COUNT(*) AS NumberOfStudents
FROM Student
WHERE St_Age IS NOT NULL;

-- 2. Display number of courses for each topic name
SELECT T.Top_Name, COUNT(C.Crs_Id) AS NumberOfCourses
FROM Topic T
JOIN Course C 
ON T.Top_Id = C.Top_Id
GROUP BY T.Top_Name;
--------------------------------------------------------------------------------------------------------------------------------------------------------

-- 3. Select Student first name and the data of his supervisor
SELECT S.St_Fname, Ins_Id, Ins_Name
FROM Student S
JOIN Instructor Sup 
ON S.St_super = Sup.Ins_Id;

-- 4. Display student with the following format (use ISNULL function)
--Student ID	Student Full Name	Department name
SELECT 
    St_Id AS [Student ID],
    ISNULL(St_Fname, '') + ' ' + ISNULL(St_Lname, '') AS [Student Full Name],
    ISNULL(Dept_Name, 'No Department') AS [Department name]
FROM Student
LEFT JOIN Department ON Student.Dept_Id = Department.Dept_Id;

-- 5. Select instructor name and his salary but if there is no salary display value ‘0000’
SELECT Ins_Name, ISNULL(Salary, 0000) AS Salary
FROM Instructor;

-- 6. Select Supervisor first name and the count of students who supervises on them
SELECT Sup.Ins_Name AS SupervisorName, COUNT(S.St_Id) AS NumberOfStudents
FROM Student S
JOIN Instructor Sup ON S.St_super = Sup.Ins_Id
GROUP BY Sup.Ins_Name;

-- 7. Display max and min salary for instructors
SELECT MAX(Salary) AS MaxSalary, MIN(Salary) AS MinSalary
FROM Instructor;

-- 8. Select Average Salary for instructors
SELECT AVG(Salary) AS AvgSalary
FROM Instructor;

-- 9. Display instructors who have salaries less than the average salary of all instructors
SELECT *
FROM Instructor
WHERE Salary < (SELECT AVG(Salary) FROM Instructor);

-- 10. Display the Department name that contains the instructor who receives the minimum salary
SELECT Dept_Name
FROM Department
WHERE Dept_Id = (
    SELECT Dept_Id
    FROM Instructor
    WHERE Salary = (SELECT MIN(Salary) FROM Instructor)
);

SELECT TOP(2) ST_ID,st_fname
from Student
order by newid()









