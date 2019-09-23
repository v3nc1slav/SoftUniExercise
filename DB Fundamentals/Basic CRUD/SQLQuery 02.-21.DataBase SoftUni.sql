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
