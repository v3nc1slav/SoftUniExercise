--PROBLEM 01
SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName, 2) = 'SA'

--PROBLEM 02
SELECT FirstName, LastName
FROM Employees
WHERE  LastName LIKE  '%ei%';

--PROBLEM 03
SELECT FirstName
FROM Employees
WHERE(DepartmentID = 3
      OR DepartmentID = 10)
	  AND  DATEPART(YEAR, HireDate)  BETWEEN 1995 AND 2005;

--PROBLEM 04
SELECT FirstName, LastName
FROM Employees
WHERE  JobTitle  NOT LIKE  '%engineer%';
