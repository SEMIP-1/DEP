--1. Create a view named EmployeeSummary to display a detailed overview of each employee.
--THE VIEW SHOULD INCLUDE: EMPLOYEE ID, NAME, GENDER, SALARY, COMPUTED AGE,
--DEPARTMENT NAME, AND DEPARTMENT LOCATION.
--(USE A JOIN BETWEEN employees AND departments.)

CREATE VIEW EmployeeSummary AS
SELECT 
    E.SSN AS EmployeeID,
    (E.FNAME + ' ' + E.LNAME) AS FullName,
    E.GENDER,
    E.SALARY,
    D.DNAME AS DepartmentName,
    D.LOCATION AS DepartmentLocation,
    DATEDIFF(YEAR, E.BIRTH, GETDATE()) AS Age
FROM EMPLOYEE E
INNER JOIN DEPARTMENT D
    ON E.SUPERVISOR_ID = D.MANAGER_ID;