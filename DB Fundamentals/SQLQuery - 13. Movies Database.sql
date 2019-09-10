CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR (50) NOT NULL, 
Notes NVARCHAR (150)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR (50) NOT NULL, 
Notes NVARCHAR (150)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR (50) NOT NULL, 
Notes NVARCHAR (150)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR (50) NOT NULL, 
DirectorId INT,
FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
CopyrightYear DATETIME,
Length DATETIME,
GenreId INT,
FOREIGN KEY (GenreId) REFERENCES Genres(Id),
Rating DECIMAL(4,2),
Notes NVARCHAR (150)
)

INSERT INTO Directors (DirectorName, Notes) VALUES
('Venci', NULL),
('Deni',NULL),
('Sanq',NULL),
('Inna', NULL),
('Viki',NULL)

INSERT INTO Genres (GenreName, Notes) VALUES
('Venci', NULL),
('Deni', NULL ),
('Sanq', NULL),
('Inna', NULL),
('Viki', NULL )

INSERT INTO Categories (CategoryName, Notes) VALUES
('Venci', NULL),
('Deni', NULL ),
('Sanq', NULL),
('Inna', NULL),
('Viki', NULL )

INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, Rating, Notes ) VALUES
('Venci',1, CONVERT(datetime, 22-03-1990,103), CONVERT(datetime, 22-03-1990,103),3, 10 ,NULL),
('Deni',3, CONVERT(datetime, 23-03-1990,103), CONVERT(datetime, 23-03-1990,103),2 , 9 ,NULL),
('Sanq',2, CONVERT(datetime, 24-03-1990,103), CONVERT(datetime, 24-03-1990,103),4 , 10 ,NULL),
('Inna',5, CONVERT(datetime, 25-03-1990,103), CONVERT(datetime, 25-03-1990,103),1 , 8 ,NULL),
('Viki',4, CONVERT(datetime, 26-03-1990,103), CONVERT(datetime, 26-03-1990,103),5 , 9 ,NULL)