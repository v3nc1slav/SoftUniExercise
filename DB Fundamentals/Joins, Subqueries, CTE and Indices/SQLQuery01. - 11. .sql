--PROBLEM 01
SELECT TOP(5) EmployeeId, JobTitle, Employees.AddressId,	AddressText
FROM Employees
JOIN Addresses ON Addresses.AddressID = Employees.AddressID
ORDER BY AddressId 

--PROBLEM 02
SELECT TOP(50) FirstName, LastName, Towns.Name, AddressText
FROM Employees
JOIN Addresses ON Addresses.AddressID = Employees.AddressID
JOIN Towns ON Addresses.TownID = Towns.TownID
ORDER BY FirstName ,  LastName

--PROBLEM 03
SELECT EmployeeID, FirstName, LastName, Departments.Name
FROM Employees
JOIN Departments ON Departments.DepartmentID = Employees.DepartmentID
WHERE Departments.Name = 'Sales'

--PROBLEM 04
SELECT TOP(5) EmployeeID, FirstName, Salary, Departments.Name
FROM Employees
JOIN Departments ON Departments.DepartmentID = Employees.DepartmentID
WHERE Salary > 15000
ORDER BY Employees.DepartmentID

--PROBLEM 05
SELECT TOP(3) Employees.EmployeeID, FirstName
FROM Employees
  LEFT OUTER JOIN EmployeesProjects ON EmployeesProjects.EmployeeID = Employees.EmployeeID
  WHERE EmployeesProjects.EmployeeID IS NULL
ORDER BY Employees.EmployeeID 

--PROBLEM 06
SELECT FirstName, LastName, HireDate, Departments.Name
FROM Employees
  JOIN Departments ON Departments.DepartmentID = Employees.DepartmentID
WHERE HireDate > '1999/01/01' AND( Departments.Name = 'Sales' OR Departments.Name = 'Finance' )
ORDER BY HireDate 

--PROBLEM 07
SELECT TOP(5) Employees.EmployeeID, FirstName, Projects.Name
FROM Employees
  JOIN EmployeesProjects ON EmployeesProjects.EmployeeID = Employees.EmployeeID
  JOIN Projects ON EmployeesProjects.ProjectID = Projects.ProjectID
WHERE Projects.StartDate > '2002/08/13'

--PROBLEM 08
SELECT Employees.EmployeeID, FirstName,
	CASE
		WHEN Projects.StartDate > '2005/01/01' THEN NULL
		ELSE Projects.Name
	END AS ProjectName
FROM Employees
  JOIN EmployeesProjects ON EmployeesProjects.EmployeeID = Employees.EmployeeID
  JOIN Projects ON EmployeesProjects.ProjectID = Projects.ProjectID 
WHERE Employees.EmployeeID = 24 