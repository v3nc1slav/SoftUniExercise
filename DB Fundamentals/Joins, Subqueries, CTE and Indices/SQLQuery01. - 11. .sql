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

