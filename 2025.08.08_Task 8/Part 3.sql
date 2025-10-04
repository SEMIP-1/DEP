--Part 03
use MyCompany

-- 1. Retrieve the names of all employees in department 10 who work more than or equal 10 hours per week on the "AL Rabwah" project.
SELECT E.Fname, E.Lname
FROM Employee E
JOIN Works_for W ON E.SSN = W.Essn
JOIN Project P ON W.Pno = P.Pnumber
WHERE E.Dno = 10 AND P.Pname = 'AL Rabwah' AND W.Hours >= 10;

-- 2. Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name
SELECT E.Fname, E.Lname, P.Pname
FROM Employee E
JOIN Works_for W ON E.SSN = W.Essn
JOIN Project P ON W.Pno = P.Pnumber
ORDER BY P.Pname;

-- 3. For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.
SELECT P.Pnumber, D.Dname, E.Lname, E.Address, E.Bdate
FROM Project P
JOIN Departments D ON P.Dnum = D.Dnum
JOIN Employee E ON D.MGRSSN = E.SSN
WHERE P.Plocation = 'Cairo';

-- 4. Display the data of the department which has the smallest employee ID over all employees ID.
SELECT TOP 1 D.*
FROM Departments D
JOIN Employee E ON D.Dnum = E.Dno
ORDER BY E.SSN ASC;

-- 5. List the last name of all managers who have no dependents
SELECT E.Lname
FROM Employee E
JOIN Departments D ON E.SSN = D.Mgrssn
WHERE E.SSN NOT IN (SELECT Essn FROM Dependent);

-- 6. For each department
-- if its average salary is less than the average salary of all employees display its number, name and number of its employees.
SELECT D.Dnum, D.Dname, COUNT(E.SSN) AS NumEmployees
FROM Departments D
JOIN Employee E ON D.Dnum = E.Dno
GROUP BY D.Dnum, D.Dname
HAVING AVG(E.Salary) < (SELECT AVG(Salary) FROM Employee);

-- 7. Try to get the max 2 salaries using subquery
SELECT DISTINCT Salary
FROM Employee E1
WHERE 2 >= (
    SELECT COUNT(DISTINCT Salary)
    FROM Employee E2
    WHERE E2.Salary >= E1.Salary
)
ORDER BY Salary DESC;
