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

--PROBLEM 15
SELECT *
INTO MY
FROM Employees
WHERE Salary > 30000

DELETE FROM MY
WHERE ManagerID = 42;

UPDATE MY
SET Salary +=5000
WHERE DepartmentID = 1;

SELECT DepartmentID, AVG(Salary)
FROM MY
GROUP BY DepartmentID

--PROBLEM 16
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING  MAX(Salary)  NOT BETWEEN 30000 AND 70000

--PROBLEM 17
SELECT COUNT (Salary) AS Count
FROM Employees
WHERE ManagerID IS NULL

--PROBLEM 18
SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary
FROM(
	SELECT DepartmentID, Salary ,
	 DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
	FROM Employees
	) MY
WHERE Rank = 3 

--PROBLEM 19
SELECT TOP (10) FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE Salary >
(
    SELECT AVG(Salary)
    FROM Employees AS em
    WHERE e.DepartmentID = em.DepartmentID
);