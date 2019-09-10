Create Database Minions
GO

CREATE TABLE Minions(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL,
Age INT ,
TownId INT FOREIGN KEY REFERENCES Towns(Id)  
)
GO

CREATE TABLE Towns (
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL,
)
GO

INSERT INTO Towns (Id, Name) VALUES
(1,	'Sofia'),
(2,	'Plovdiv'),
(3,	'Varna')
GO

INSERT INTO Minions (Id, Name, Age, TownId) VALUES
(1,	'Kevin', 22,1),
(2,	'Bob',15,3),
(3,	'Steward',0,2)