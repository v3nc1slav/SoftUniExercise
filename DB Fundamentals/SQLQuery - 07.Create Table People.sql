CREATE DATABASE People 

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(200)NOT NULL,
Picture VARCHAR(MAX),
Height  DECIMAL(5,2)NOT NULL,
Weight DECIMAL(5,2)NOT NULL,
[Gender] char(1) Not null CHECK(Gender='m' OR Gender='f'),
Birthdate DATE NOT NULL,
Biography VARCHAR(MAX)
)

INSERT INTO People(Name,Picture,Height,Weight,Gender,Birthdate,Biography) Values
('Stela',Null,1.65,44.55,'f',CONVERT(datetime,'22-09-2002',103),Null),
('Ivan',Null,2.15,95.55,'m',CONVERT(datetime,'22-09-2002',103),Null),
('Qvor',Null,1.55,33.00,'m',CONVERT(datetime,'22-09-2002',103),Null),
('Karolina',Null,2.15,55.55,'f',CONVERT(datetime,'22-09-2002',103),Null),
('Pesho',Null,1.85,90.00,'m',CONVERT(datetime,'22-09-2002',103),Null)