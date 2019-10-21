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