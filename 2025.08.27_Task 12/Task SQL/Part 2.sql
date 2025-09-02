--1. Create a scalar function to calculate employee bonus based on gender.
--(FEMALES RECEIVE 10%, MALES RECEIVE 5% OF SALARY AS BONUS.)
CREATE FUNCTION dbo.CalculateBonus
(
    @Salary DECIMAL(10,2),
    @Gender CHAR(1)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @Bonus DECIMAL(10,2);

    IF @Gender = 'F'
        SET @Bonus = @Salary * 0.10;
    ELSE IF @Gender = 'M'
        SET @Bonus = @Salary * 0.05;
    ELSE
        SET @Bonus = 0;

    RETURN @Bonus;
END;
GO
--2. Create a stored procedure to apply bonuses by updating salaries using the bonus function.
CREATE PROCEDURE dbo.ApplyBonuses
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE EMPLOYEE
    SET Salary = Salary + dbo.CalculateBonus(Salary, Gender);
END;
GO
--3. Create a stored procedure to insert a new employee with validation on department existence.
--(CHECK WHETHER THE PROVIDED dept_id EXISTS BEFORE INSERTING THE EMPLOYEE.)
CREATE PROCEDURE dbo.AddEmployee
(
    @FName NVARCHAR(50),
    @LName NVARCHAR(50),
    @Birth DATE,
    @Gender CHAR(1),
    @Salary DECIMAL(10,2),
    @DeptID INT
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validate department existence
    IF EXISTS (SELECT 1 FROM DEPARTMENT WHERE DNUM = @DeptID)
    BEGIN
        INSERT INTO EMPLOYEE (FNAME, LNAME, BIRTH, GENDER, SALARY, SUPERVISOR_ID)
        VALUES (@FName, @LName, @Birth, @Gender, @Salary, NULL);

        PRINT 'Employee added successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Error: Department does not exist.';
    END
END;
GO

--4.  Create a stored procedure to generate a department-level report.
--This report should include the total number of employees per department and the average salary in each department. 
--(Use JOIN, COUNT(), AVG(), and GROUP BY.)
--??

--5.  Create a scalar function to calculate employee tenure (years of service).
--The function should return the number of full years between two dates: a start date 
--(e.g., project start or hire date) and an end date (or today if still active).
CREATE FUNCTION dbo.CalculateTenure
(
    @StartDate DATE,
    @EndDate DATE
)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(YEAR, @StartDate, ISNULL(@EndDate, GETDATE()));
END;
GO