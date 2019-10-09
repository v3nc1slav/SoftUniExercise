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

--PROBLEM 05
SELECT Name
FROM Towns 
WHERE LEN(Name) BETWEEN 5 AND 6
ORDER BY Name

--PROBLEM 06
SELECT *
FROM Towns
WHERE LEFT(Name, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name

-- PROBLEM 07
SELECT *
FROM Towns
WHERE NOT LEFT(Name, 1) IN ('R', 'D', 'B')
ORDER BY Name

-- PROBLEM 08
CREATE VIEW V_EmployeesHiredAfter2000 
AS
     SELECT FirstName,
            LastName
     FROM Employees
     WHERE DATEPART(YEAR, HireDate) > 2000;

-- PROBLEM 09
 SELECT FirstName, LastName
 FROM Employees
 WHERE LEN(LastName) =5

 --PROBLEM 10
 SELECT EmployeeID, FirstName, LastName, Salary,
              DENSE_RANK() over (partition by Salary ORDER BY EmployeeID) AS Rank
       FROM Employees
       WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

 --PROBLEM 11
 SELECT *
FROM (
 SELECT EmployeeID, FirstName, LastName, Salary,
              DENSE_RANK() over (partition by Salary ORDER BY EmployeeID) AS Rank
       FROM Employees
       WHERE Salary BETWEEN 10000 AND 50000) AS MyTable
WHERE Rank = 2
ORDER BY Salary DESC