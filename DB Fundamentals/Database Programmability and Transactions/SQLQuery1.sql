--PROBLEM 01
--FOR judge
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
     BEGIN
         SELECT FirstName AS [First Name],
                LastName AS [Last Name]
         FROM Employees
         WHERE Salary > 35000;
     END; 

-- EXEC udp_GetEmployeesSalaryAbove35000;

--PROBLEM 01
--SECAND
CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
   SELECT FirstName AS [First Name],
          LastName AS [Last Name]
   FROM Employees
   WHERE Salary > 35000;

 EXEC udp_GetEmployeesSalaryAbove35000;

 --PROBLEM 02
 CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @SalaryAboveNumber DECIMAL(16,4)
AS
BEGIN
   SELECT FirstName AS [First Name],
          LastName AS [Last Name]
   FROM Employees
   WHERE Salary >= @SalaryAboveNumber;
END;

-- EXEC usp_GetEmployeesSalaryAboveNumber @SalaryAboveNumber=3500 ;

--PROBLEM 03
CREATE PROCEDURE usp_GetTownsStartingWith  @townNames NVARCHAR(30)
AS
BEGIN
   SELECT t.Name AS Towe
   FROM Towns AS t 
   WHERE (t.Name) LIKE @townNames+'%';
END;

--EXEC usp_GetTownsStartingWith  Sofi

--PROBLEM 04
CREATE PROCEDURE usp_GetEmployeesFromTown @townNames NVARCHAR(30)
AS
BEGIN
   SELECT e.FirstName, e.LastName
   FROM Employees AS e 
   JOIN Addresses AS a ON a.AddressID = e.AddressID
   JOIN Towns AS t ON t.TownID = a.TownID
   WHERE (t.Name) LIKE @townNames+'%';
END;

--EXEC usp_GetEmployeesFromTown  SOFIA

--PROBLEM 05
CREATE or alter  FUNCTION ufn_GetSalaryLevel(@salary INT)
RETURNS  NVARCHAR(10) 
BEGIN
DECLARE @salaryLevel NVARCHAR(10)
	IF (@salary < 30000)
	SET @salaryLevel = 'Low'
	ELSE IF @salary <= 50000
	SET @salaryLevel = 'Average'
	ELSE
	SET @salaryLevel = 'High'
	RETURN @salaryLevel
END;

--SELECT e.Salary, DBO.ufn_GetSalaryLevel(E.Salary) AS [Salary Level] FROM Employees AS e

--PROBLEM 06
CREATE or alter PROCEDURE usp_EmployeesBySalaryLevels(@text VARCHAR(7))
AS
     BEGIN
         SELECT FirstName AS [First Name],
                LastName AS [Last Name]
         FROM Employees
         WHERE dbo.ufn_GetSalaryLevel(Salary) = @text;
     END;

-- EXEC dbo.usp_EmployeesBySalaryLevels  'low'


-- PROBLEM 07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR (50), @word VARCHAR (50)) 
RETURNS BIT
AS
BEGIN
     DECLARE @index INT = 1
     DECLARE @letter CHAR(1)
     WHILE (@index <= LEN(@word))
     BEGIN
          SET @letter = SUBSTRING(@word, @index, 1)
          IF (CHARINDEX(@letter, @setOfLetters) > 0)
             SET @index = @index + 1
          ELSE
             RETURN 0
     END
     RETURN 1
END 

--PROBLEM 08
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
(
                 @departmentId INT
)
AS
     BEGIN
         ALTER TABLE Employees ALTER COLUMN ManagerID INT;

         ALTER TABLE Employees ALTER COLUMN DepartmentID INT;

         UPDATE Employees
           SET
               DepartmentID = NULL
         WHERE EmployeeID IN
         (
         (
             SELECT EmployeeID
             FROM Employees
             WHERE DepartmentID = @departmentId
         )
         );

         UPDATE Employees
           SET
               ManagerID = NULL
         WHERE ManagerID IN
         (
         (
             SELECT EmployeeID
             FROM Employees
             WHERE DepartmentID = @departmentId
         )
         );

         ALTER TABLE Departments ALTER COLUMN ManagerID INT;

         UPDATE Departments
           SET
               ManagerID = NULL
         WHERE DepartmentID = @departmentId;

         DELETE FROM Departments
         WHERE DepartmentID = @departmentId;

         DELETE FROM EmployeesProjects
         WHERE EmployeeID IN
         (
         (
             SELECT EmployeeID
             FROM Employees
             WHERE DepartmentID = @departmentId
         )
         );

         DELETE FROM Employees
         WHERE DepartmentID = @departmentId;

         SELECT COUNT(*)
         FROM Employees
         WHERE DepartmentID = @departmentId;
     END;





