--Part 01
use ITI
--1. Select max two salaries in the instructor table
SELECT DISTINCT TOP 2 Salary
FROM Instructor
WHERE Salary IS NOT NULL
ORDER BY Salary DESC;

--2. Highest two salaries in each department (with ranking)
SELECT Dept_ID, Ins_Name, Salary
FROM (
    SELECT Dept_ID, Ins_Name, Salary,
           DENSE_RANK() OVER (PARTITION BY Dept_ID ORDER BY Salary DESC) AS SalaryRank
    FROM Instructor
    WHERE Salary IS NOT NULL
) AS Ranked
WHERE SalaryRank <= 2
ORDER BY Dept_ID, Salary DESC;
--3. Random student from each department (ranking function)

SELECT Dept_ID, St_Fname, St_Lname
FROM (
    SELECT Dept_ID, St_Fname, St_Lname,
           ROW_NUMBER() OVER (PARTITION BY Dept_ID ORDER BY NEWID()) AS RowNum
    FROM Student
) AS Randomized
WHERE RowNum = 1;