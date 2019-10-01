USE SoftUni

--PROBLEM 02
SELECT *
FROM Departments

--PROBLEM 03
SELECT NAME
FROM Departments

--PROBLEM 04
SELECT FirstName, LastName , Salary
FROM Employees

--PROBLEM 05
SELECT FirstName,MiddleName, LastName 
FROM Employees

--PROBLEM 06
SELECT FirstName+'.'+LastName+'@softuni.bg' AS 'Full Email Address'
FROM Employees

--PROBLEM 07
SELECT DISTINCT Salary
FROM Employees
ORDER BY Salary 

--PROBLEM 08
SELECT *
FROM Employees
WHERE  JobTitle = 'Sales Representative';

--PROBLEM 09
SELECT FirstName, LastName, JobTitle
FROM Employees
WHERE Salary>=20000 AND Salary<=30000

--PROBLEM 10
SELECT FirstName+' '+MiddleName+' '+LastName AS 'Full Name'
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--PROBLEM 11
SELECT  FirstName, LastName
FROM Employees
WHERE ManagerID is null

--PROBLEM 12
SELECT  FirstName, LastName, Salary
FROM Employees
WHERE Salary >= 50000
ORDER BY Salary DESC

--PROBLEM 13
SELECT TOP 5 FirstName, LastName
FROM Employees
ORDER BY Salary DESC

--PROBLEM 14
SELECT  FirstName, LastName
FROM Employees
WHERE DepartmentId != 4

--PROBLEM 15
SELECT *
FROM Employees
ORDER BY Salary DESC, FirstName, LastName DESC

--PROBLEM 16
CREATE VIEW [V_EmployeesSalaries] AS
SELECT FirstName, LastName, Salary
FROM Employees

--PROBLEM 17
CREATE VIEW V_EmployeeNameJobTitle  AS
SELECT FirstName + ' '+ ISNULL(MiddleName, '')+' ' + LastName  AS 'Full Name' , JobTitle
FROM Employees
