--PROMLEM 01

CREATE DATABASE TableRelations;

CREATE TABLE Passports
(
             PassportID     INT IDENTITY(101, 1) NOT NULL,
             PassportNumber CHAR(8) NOT NULL,

             CONSTRAINT PK_Passports PRIMARY KEY(PassportID)
);

CREATE TABLE Persons
(
             PersonId   INT IDENTITY NOT NULL,
             FirstName  NVARCHAR(50) NOT NULL,
             Salary     DECIMAL(10, 2),
             PassportID INT

             UNIQUE NOT NULL,
             CONSTRAINT PK_Persons PRIMARY KEY(PersonId),
             CONSTRAINT FK_Persons_Passports FOREIGN KEY(PassportID) REFERENCES Passports(PassportID) ON DELETE CASCADE
);

INSERT INTO Passports
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2');

INSERT INTO Persons
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101);

--PROBLEM 02
CREATE TABLE Manufacturers
(
             ManufacturerID INT IDENTITY NOT NULL,
             Name           VARCHAR(50) NOT NULL,
             EstablishedOn  DATE DEFAULT GETDATE(),

             CONSTRAINT PK_Manufacturers PRIMARY KEY(ManufacturerID)
);

CREATE TABLE Models
(
             ModelID        INT NOT NULL,
             Name           VARCHAR(50) NOT NULL,
             ManufacturerID INT NOT NULL,

             CONSTRAINT PK_Models PRIMARY KEY(ModelID),
             CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
);

INSERT INTO Manufacturers
VALUES
('BMW', '07/03/1916'),
('Tesla','01/01/2003'),
('Lada', '01/05/1966');

INSERT INTO Models
VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3); 

--PROBLEM 03
CREATE TABLE Students
(	
	StudentID INT IDENTITY NOT NULL,
	Name NVARCHAR(255) NOT NULL 
	
	CONSTRAINT PK_Students PRIMARY KEY(StudentID)
); 

CREATE TABLE Exams
(
	ExamID INT NOT NULL, 
	Name NVARCHAR(255) NOT NULL 
	
	CONSTRAINT PK_Exams PRIMARY KEY(ExamID)
);

CREATE TABLE StudentsExams
(
   StudentID INT NOT NULL,
   ExamID    INT NOT NULL,

   CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID),
   CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
   CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
);

INSERT INTO Students
VALUES
('Mila'),
('Toni'),
('Ron');

INSERT INTO Exams
VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g');

INSERT INTO StudentsExams
VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103); 

--PROBLEM 04
CREATE TABLE Teachers
(
             TeacherID INT NOT NULL,
             Name      NVARCHAR(255),
             ManagerID INT,

             CONSTRAINT PK_Teachers PRIMARY KEY(TeacherID),
             CONSTRAINT FK_Teachers_Teachers FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers
VALUES
(101,'John',NULL),
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted',105),
(105,'Mark',101),
(106,'Greta',101); 