--1. Create a trigger to display an alert when a new employee is inserted.
--THIS TRIGGER SHOULD EXECUTE AFTER A NEW ROW IS INSERTED INTO THE employees
--TABLE AND PRINT A MESSAGE WITH THE EMPLOYEE'S NAME AND DEPARTMENT ID.
--(USE THE INSERTED PSEUDO-TABLE AND PRINT STATEMENT.)
CREATE TRIGGER trg_NewEmployeeAlert
ON EMPLOYEE
AFTER INSERT
AS
BEGIN
    DECLARE @FName NVARCHAR(50),
            @LName NVARCHAR(50),
            @DeptID INT;

    SELECT @FName = FNAME, 
           @LName = LNAME, 
           @DeptID = SUPERVISOR_ID 
    FROM INSERTED;

    PRINT 'New employee added: ' + @FName + ' ' + @LName +
          ' in Department ID: ' + CAST(@DeptID AS NVARCHAR(10));
END;
GO

--2. Create a table named salary_changes to store salary modification history.
--THIS AUDIT TABLE SHOULD STORE: EMPLOYEE ID, OLD SALARY, NEW SALARY, DATE OF
--CHANGE, AND OPTIONALLY THE USER WHO MADE THE CHANGE.
CREATE TABLE salary_changes
(
    ChangeID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE(),
    ChangedBy SYSNAME DEFAULT SUSER_SNAME()  -- optional: captures current user
);
GO

--3. Create a trigger to log every salary update into the salary_changes table.
--THIS TRIGGER SHOULD FIRE AFTER ANY UPDATE ON THE salary COLUMN IN THE
--employees TABLE, AND INSERT A NEW ROW INTO salary_changes FOR EACH SALARY
--MODIFICATION.
--(USE BOTH INSERTED AND DELETED PSEUDO-TABLES TO COMPARE VALUES.)
CREATE TRIGGER trg_LogSalaryChange
ON EMPLOYEE
AFTER UPDATE
AS
BEGIN
    INSERT INTO salary_changes (EmployeeID, OldSalary, NewSalary)
    SELECT 
        d.SSN,            -- Employee ID
        d.SALARY,         -- Old salary from DELETED table
        i.SALARY          -- New salary from INSERTED table
    FROM DELETED d
    INNER JOIN INSERTED i ON d.SSN = i.SSN
    WHERE d.SALARY <> i.SALARY; -- Only log if salary actually changed
END;
GO
--USED CHAT GPT
------------------------------------------
--CHECK OUTPUT
INSERT INTO EMPLOYEE (SSN, FNAME, LNAME, BIRTH, GENDER, SALARY, SUPERVISOR_ID)
VALUES (51, 'Sara', 'Hassan', '1995-04-15', 'Female', 25569, 10);
GO


UPDATE EMPLOYEE
SET SALARY = SALARY + 1000
WHERE SSN = 51;
GO