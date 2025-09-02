CREATE DATABASE DEP_COMPANY
GO
USE DEP_COMPANY
GO
--1. Display all employees along with their computed ages.
--(USE A COMPUTED COLUMN FOR AGE BASED ON BIRTHDATE.)
SELECT SSN, FNAME, LNAME, BIRTH,
       DATEDIFF(YEAR, BIRTH, GETDATE()) AS AGE
FROM EMPLOYEE;
--GOT IT BY CHATGPT AS A SHORTCUT DATEDIFF

--2. Display employees along with their department names and locations.
--(USE INNER JOIN BETWEEN employees AND departments.)
SELECT E.SSN, E.FNAME, E.LNAME, D.DNAME, D.LOCATION
FROM EMPLOYEE E
INNER JOIN DEPARTMENT D
ON E.SUPERVISOR_ID = D.MANAGER_ID;

--3. Display each department along with the number of employees in it.
--(USE AGGREGATION AND GROUP BY WITH COUNT() FUNCTION.)
SELECT D.DNAME, COUNT(E.SSN) AS EmployeeCount
FROM DEPARTMENT D
LEFT JOIN EMPLOYEE E
ON D.DNUM = E.SUPERVISOR_ID  -- Or department ID column if present
GROUP BY D.DNAME;

--4. List employees who are working on projects managed by their own departments.
--(USE JOIN ACROSS employees, departments, AND projects TABLES.)
SELECT DISTINCT E.SSN, E.FNAME, E.LNAME
FROM EMPLOYEE E
JOIN WORKING_PROJECTS W
  ON E.SSN = W.EM_SSN
JOIN PROJECT P
  ON W.P_NUM = P.PNUMBER
JOIN DEPARTMENT D
  ON P.DEPARTMENT_ID = D.DNUM
WHERE E.SUPERVISOR_ID = D.MANAGER_ID;

--5. Display projects that end in the year 2024 only.
--(USE WHERE WITH THE YEAR() FUNCTION ON end_date.)
SELECT PNUMBER, PNAME, END_DATE
FROM PROJECT
WHERE YEAR(END_DATE) = 2024;

--6. Find employees who have their birthday today.
--(MATCH DAY() AND MONTH() OF BIRTHDATE WITH TODAY’S DATE.)
SELECT SSN, FNAME, LNAME, BIRTH
FROM EMPLOYEE
WHERE DAY(BIRTH) = DAY(GETDATE())
  AND MONTH(BIRTH) = MONTH(GETDATE());
--with help

--7. Calculate average salary grouped by gender.
--(USE AVG(salary) AND GROUP BY gender.)
SELECT GENDER, Avg(SALARY) AS AvgSalary
FROM EMPLOYEE
GROUP BY GENDER;

--8. List departments that do not have any projects assigned to them.
--(USE NOT EXISTS OR A LEFT JOIN WITH NULL CHECK.)
SELECT D.DNUM, D.DNAME
FROM DEPARTMENT D
LEFT JOIN PROJECT P
  ON D.DNUM = P.DEPARTMENT_ID
WHERE P.PNUMBER IS NULL;

--9. Display salary statistics (min, max, avg) for each department.
--(USE AGGREGATION FUNCTIONS GROUPED BY DEPARTMENT.)
SELECT D.DNAME,
       MIN(E.SALARY) AS MinSalary,
       MAX(E.SALARY) AS MaxSalary,
       AVG(E.SALARY) AS AvgSalary
FROM DEPARTMENT D
JOIN EMPLOYEE E
  ON D.MANAGER_ID = E.SUPERVISOR_ID 
GROUP BY D.DNAME;
--10. List employees who have worked on more than one project.
--(ASSUMING AN INTERMEDIATE TABLE LIKE employee_projects, USE GROUP BY AND HAVING COUNT > 1.)
SELECT W.EM_SSN, COUNT(W.P_NUM) AS ProjectCount
FROM WORKING_PROJECTS W
GROUP BY W.EM_SSN
HAVING COUNT(W.P_NUM) > 1;

--11. Rank employees by salary within each department.
--(USE RANK() OR DENSE_RANK() WITH PARTITION BY IN A WINDOW FUNCTION.)
SELECT E.SSN, E.FNAME, E.LNAME, D.DNAME,
       RANK() OVER (PARTITION BY D.DNUM ORDER BY E.SALARY DESC) AS SalaryRank
FROM EMPLOYEE E
JOIN DEPARTMENT D
  ON E.SUPERVISOR_ID = D.MANAGER_ID;

--12. Display IT department projects that exceed the department's average project budget.
--(USE A SUBQUERY TO FILTER BASED ON AVERAGE BUDGET.)
--??

--13. Calculate the total company payroll (monthly and annually).
--(USE SUM(salary) AND MULTIPLY FOR ANNUAL PAYROLL ESTIMATE.)
SELECT SUM(SALARY) AS MonthlyPayroll,
       SUM(SALARY) * 12 AS AnnualPayroll
FROM EMPLOYEE;