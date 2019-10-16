--PROBLEM 13
SELECT DepartmentID, SUM(Salary) TotalSalary
FROM Employees
GROUP BY DepartmentID  

--PROBLEM 14
SELECT DepartmentID, MIN(Salary) MinimumSalary
FROM Employees
WHERE HireDate > '2000/01/01'
GROUP BY DepartmentID  
HAVING  DepartmentID IN (2,5 ,7)
