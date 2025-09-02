--Part 02
Use MyCompany

--DQL:
-- 1. For each project, list the project name and the total hours per week (for all employees) spent on that project.
SELECT P.Pname, SUM(W.Hours) AS TotalHours
FROM Project P
JOIN Works_for W ON P.Pnumber = W.Pno
GROUP BY P.Pname;

-- 2. For each department, retrieve the department name and the maximum, minimum and average salary of its employees.
SELECT D.Dname, MAX(E.Salary) AS MaxSalary, MIN(E.Salary) AS MinSalary, AVG(E.Salary) AS AvgSalary
FROM Departments D
JOIN Employee E ON D.Dnum = E.Dno
GROUP BY D.Dname;

-- 3. Retrieve a list of employees and the projects they are working on ordered by department and within each department, ordered alphabetically by last name, first name.
SELECT E.Fname, E.Lname, P.Pname
FROM Employee E
JOIN Works_for W ON E.SSN = W.ESSn
JOIN Project P ON W.Pno = P.Pnumber
ORDER BY E.Dno, E.Lname, E.Fname;

-- 4. Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30% 
UPDATE Employee
SET Salary = Salary * 1.3
WHERE SSN IN (
    SELECT SSN
    FROM Works_for W
    JOIN Project P ON W.Pno = P.Pnumber
    WHERE P.Pname = 'Al Rabwah'
);

--DML:
-- 1. In the department table insert a new department called "DEPT IT" , with id 100, employee with SSN = 112233 as a manager for 
--.this department. The start date for this manager is '1-11-2006'.
INSERT INTO Departments (Dname, Dnum, MGRSSN, [MGRStart Date])
VALUES ('DEPT IT', 100, 112233, '2006-11-01');

-- 2. Do what is required if you know that : Mrs.Noha Mohamed(SSN=968574)  moved to be the manager of the new department (id = 100), 
--and they give you(your SSN =102672) her position (Dept. 20 manager) 
-- a. Update Mrs.Noha Mohamed to manage department 100
UPDATE Departments
SET MGRSSN = 968574
WHERE Dnum = 100;
-- b. Update your record to be department 20 manager
UPDATE Departments
SET MGRSSN = 102672
WHERE Dnum = 20;
-- c. Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672)
UPDATE Employee
SET Superssn = 102672
WHERE SSN = 102660;

-- 3. Unfortunately the company ended the contract with  Mr.Kamel Mohamed (SSN=223344) so try to delete him from your database in case you know that you will be temporarily in his position.
--Hint: (Check if Mr. Kamel has dependents, works as a department manager, supervises any employees or works in any projects and handles these cases).
-- Remove dependent records
DELETE FROM Dependent WHERE Essn = 223344;
-- Remove works_on records
DELETE FROM Works_for WHERE Essn = 223344;
-- If he is manager, update department
UPDATE Departments SET MGRSSN = 102672 WHERE MGRSSN = 223344;
-- If he supervises employees, update their supervisor
UPDATE Employee SET Superssn = 102672 WHERE Superssn = 223344;
-- Finally delete employee
DELETE FROM Employee WHERE SSN = 223344;