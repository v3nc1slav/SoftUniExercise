CREATE DATABASE CarRental 

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR (50) NOT NULL,
DailyRate DECIMAL (15,2) NOT NULL,
WeeklyRate DECIMAL (15,2) NOT NULL,
MonthlyRate DECIMAL (15,2) NOT NULL,
WeekendRate DECIMAL (15,2) NOT NULL,
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber NVARCHAR (10) NOT NULL,
Manufacturer NVARCHAR (50) NOT NULL,
Model NVARCHAR (50) NOT NULL,
CarYear INT,
CategoryId INT,
FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
Doors NVARCHAR (50),
Picture VARCHAR (MAX),
Condition NVARCHAR (50),
Available NVARCHAR (50),
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR (50) NOT NULL,
LastName NVARCHAR (50) NOT NULL,
Title NVARCHAR (50) NOT NULL,
Notes NVARCHAR (50) 
)


CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber NVARCHAR (50) NOT NULL,
FullName NVARCHAR (50) NOT NULL,
Address NVARCHAR (50) NOT NULL,
City NVARCHAR (20) NOT NULL,
ZIPCode VARCHAR (10) NOT NULL,
Notes NVARCHAR (50) 
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT,
FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
CustomerId INT,
FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
CarId INT,
FOREIGN KEY (CarId) REFERENCES Cars(Id),
TankLevel INT,
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage INT,
StartDate DATETIME,
EndDate DATETIME,
TotalDays INT ,
RateApplied INT NOT NULL,
TaxRate INT NOT NULL,
OrderStatus VARCHAR (50)NOT NULL,
Notes VARCHAR(150)
)

 
INSERT INTO Categories( CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('LIGHT AVOMOBILE', 121.52, 235.25, 526.35, 150.00 ),
('COMMERCIAL CAR', 121.62, 235.45, 526.75, 151.00 ),
('CARAVAN', 121.62, 235.45, 526.75, 151.00 )

INSERT INTO Cars ( PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)VALUES
('DR2568DE', 'RENO', 'MEGAN' , NULL, 1, NULL, NULL, 'YES', NULL ),
('DR7568DE', 'AUDI', 'X7' , NULL, 1, NULL, NULL, 'YES', NULL ),
('RR2568DE', 'BMV', 'D5' , NULL, 1, NULL, NULL, 'YES', NULL )

INSERT INTO	Employees (FirstName, LastName, Title, Notes)VALUES
('Venci','VERCHOV','BDAHDAB', NULL),
('Deni','PANOV',   'BDAHDAJB', NULL),
('Sanq', 'PANOVA', 'BDAHDAJB', NULL)

INSERT INTO	Customers ( DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)VALUES
('DRS2569SA', 'VENCISLAV VERCHOV', 'BULGARIA', 'SOFIA', 1000, NULL ),
('DRS2669SA', 'VENCISLAV VERCHOV', 'BULGARIA', 'SOFIA', 1000, NULL ),
('DRS2579SA', 'VENCISLAV VERCHOV', 'BULGARIA', 'SOFIA', 1000, NULL )


INSERT INTO RentalOrders ( EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
 TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)VALUES
 (1, 2, 2, 60, NULL, NULL, 20000, NULL, NULL, NULL, 100, 50, 'GOOD', NULL),
 (2, 2, 1, 60, NULL, NULL, 20000, NULL, NULL, NULL, 100, 50, 'GOOD', NULL), 
 (3, 2, 3, 60, NULL, NULL, 20000, NULL, NULL, NULL, 100, 50, 'GOOD', NULL) 