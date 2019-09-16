CREATE DATABASE SoftUni

CREATE TABLE Towns(
ID INT PRIMARY KEY IDENTITY,
Name  NVARCHAR (50) NOT NULL,
)

CREATE TABLE Addresses(
ID INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR (50) NOT NULL,
TownId INT,

FOREIGN KEY (TownId) REFERENCES Towns(Id),
)

CREATE TABLE Departments(
ID INT PRIMARY KEY IDENTITY,
Name  NVARCHAR (50) NOT NULL,
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR (50) NOT NULL,
MiddleName NVARCHAR (50) NOT NULL,
LastName NVARCHAR (50) NOT NULL,
JobTitle NVARCHAR (50),
DepartmentId INT,
HireDate DATE,
Salary DECIMAL (15,2),
AddressId INT,

FOREIGN KEY (DepartmentId) REFERENCES Departments(ID), 
FOREIGN KEY (AddressId) REFERENCES Addresses(ID), 
)

INSERT INTO Towns ( Name) VALUES 
('Sofia'),
(' Plovdiv'),
(' Varna'),
(' Burgas')

INSERT INTO Addresses ( AddressText, TownId) VALUES
('DASDFASS',1),
('DASDSASS',2),
('DFSDFASS',3),
('DASGFASS',4),
('DASYFASS',4)

INSERT INTO Departments ( Name) VALUES 
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId) VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer',4, CONVERT(datetime, 01/02/2013,103), 3500.00, 1),
('Petar', 'Petrov', 'Petrov',	'Senior Engineer',	1,CONVERT(datetime,	02/03/2004,103),	4000.00, 2),
('Maria', 'Petrova', 'Ivanova', 'Intern',	5,CONVERT(datetime,	28/08/2016,103),	525.25, 3),
('Georgi', 'Teziev', 'Ivanov',	'CEO',	2,	CONVERT(datetime,09/12/2007,103),	3000.00, 4),
('Peter', ',Pan',' Pan','Intern',	3,	CONVERT(datetime,28/08/2016,103),	599.88, 5)

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees