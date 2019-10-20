--01
CREATE DATABASE Service

CREATE TABLE Users(
Id INT  PRIMARY KEY IDENTITY,
Username NVARCHAR(30) NOT NULL,
Password NVARCHAR (50) NOT NULL,
Name NVARCHAR(50),
Birthdate DATETIME NOT NULL,
Age INT,
Email NVARCHAR (50) NOT NULL)

CREATE TABLE Departments(
Id	INT PRIMARY KEY IDENTITY,
Name	NVARCHAR (50 )	NOT NULL
)

CREATE TABLE Employees(
Id	INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR (25),
LastName	NVARCHAR (25),
Birthdate	DATETIME,
Age	INT ,
DepartmentId	INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id	INT PRIMARY KEY IDENTITY,
Name	NVARCHAR (50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Status(
Id INT PRIMARY KEY IDENTITY,
Label NVARCHAR (30) NOT NULL)

CREATE TABLE Reports(
Id	 INT PRIMARY KEY IDENTITY,
CategoryId	INT FOREIGN KEY REFERENCES Categories(Id),
StatusId	INT FOREIGN KEY REFERENCES Status(Id),
OpenDate	DATETIME NOT NULL,
CloseDate	DATETIME,
Description	NVARCHAR (200) NOT NULL,
UserId	INT FOREIGN KEY REFERENCES Users(Id),
EmployeeId	INT FOREIGN KEY REFERENCES Employees(Id))

--02
INSERT INTO Employees (FirstName,	LastName,	Birthdate,	DepartmentId) VALUES
('Marlo',	'O Malley',	1958-9-21,	1),
('Niki', 'Stanaghan',	1969-11-26,	4),
('Ayrton',	'Senna',	1960-03-21,	9),
('Ronnie',	'Peterson',	1944-02-14,	9),
('Giovanna', 'Amati', 1959-07-20,	5)


INSERT INTO Reports (CategoryId,	StatusId,	OpenDate,	CloseDate,	Description,	UserId,	EmployeeId) VALUES
(1,	1,	2017-04-13,	NULL,	'Stuck Road on Str.133',	6,	2),
(6,	3,	2015-09-05,	2015-12-06,	'Charity trail running',	3,	5),
(14,	2,	2015-09-07,	NULL,	'Falling bricks on Str.58',	5,	2),
(4,	3,	2017-07-03,	2017-07-06,	'Cut off streetlight on Str.11',	1	,1)


--03
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--04
DELETE FROM Reports 
WHERE StatusId = 4

--05
SELECT r.Description, CONVERT(varchar,  r.OpenDate, 105) AS OpenDate
FROM Reports AS r
WHERE r.EmployeeId IS NULL
ORDER BY  r.OpenDate,  r.Description

--06
SELECT r.Description, c.Name AS CategoryName
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
ORDER BY r.Description

--07
SELECT  TOP (5) c.Name, COUNT (r.CategoryId) AS ReportsNumber
FROM Reports  AS r
JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY  C.Name
ORDER BY COUNT (r.CategoryId) DESC , c.Name

--08
SELECT u.Username, C.Name AS CategoryName
FROM Reports  AS r
JOIN Categories AS c ON r.CategoryId = c.Id
JOIN Users AS u ON r.UserId = u.Id
WHERE MONTH(U.Birthdate) = MONTH(r.OpenDate) AND 
 DAY(U.Birthdate) = DAY(r.OpenDate) 
ORDER BY u.Username, CategoryName

--09
SELECT MY.FirstName+' '+ my.LastName AS FullName, UsersCount
FROM(
SELECT e.FirstName, e.LastName,  COUNT(u.ID) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
LEFT JOIN Users AS u ON u.ID = r.UserId
GROUP BY e.FirstName, e.LastName,  e.ID) AS MY
ORDER BY MY.UsersCount DESC , FullName

--10
SELECT 
CASE 
 WHEN E.FirstName IS NULL
 THEN 'None'
 ELSE 
 e.FirstName+ ' '+E.LastName 
 END AS Employee , 
CASE
     WHEN d.Name IS NULL
     THEN 'None'
	ELSE d.Name
	END AS Department,
	 c.Name AS Category, r.Description ,CONVERT(varchar,  r.OpenDate, 104) AS OpenDate, s.Label, u.Name
FROM Reports AS r
FULL JOIN Employees AS e ON r.EmployeeId = e.Id
FULL JOIN Departments AS d ON e.DepartmentId = d.Id
FULL JOIN Categories AS c ON c.Id = r.CategoryId
FULL JOIN Status AS s ON r.StatusId = s.Id
JOIN Users AS u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, e.LastName DESC , Department, Category, r.Description, OpenDate, s.Label, u.Name



--11
CREATE FUNCTION  udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT 
AS
BEGIN
  DECLARE @RESULT INT =  DATEDIFF(hour, @StartDate, @EndDate)
  IF @StartDate = 0
  SET @RESULT = 0
  IF  @EndDate = 0
  SET @RESULT =0
RETURN @RESULT
END;

--12
CREAT PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
SELECT *
FROM Reports AS r
JOIN Employees AS e ON r.EmployeeId = E.Id
JOIN Categories AS c ON r.CategoryId = c.Id
JOIN Departments AS d ON e.DepartmentId = d.Id
WHERE e.DepartmentId = 
