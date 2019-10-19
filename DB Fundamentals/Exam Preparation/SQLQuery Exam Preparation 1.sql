--02
INSERT INTO Planes(Name,	Seats,	Range) VALUES
('Airbus 336',	112,5132),
('Airbus 330',	432,5325),
('Boeing 369',	231,2355),
('Stelt 297',	254,2143),
('Boeing 338',	165,5111),
('Airbus 558',	387,1342),
('Boeing 128',	345,5541)


INSERT INTO LuggageTypes (Type) VALUES
('Crossbody Bag		'),
('School Backpack	'),
('Shoulder Bag		')

--03
UPDATE Tickets
 SET Price *= 1.13
 WHERE FlightId =  41

--04
DELETE FROM Tickets
WHERE FlightId = 30

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

select *
from Flights as f 
WHERE Destination = 'Ayn Halagim'

--05
SELECT *
FROM Planes
WHERE NAME LIKE '%TR%'
ORDER BY Id,	Name,	Seats,	Range

--06
SELECT f.Id,SUM(T.Price) AS Price
FROM Tickets AS t
JOIN Flights AS f ON f.Id = t.FlightId
GROUP BY F.Id
ORDER BY Price DESC, f.Id

--07
SELECT p.FirstName+' '+p.LastName AS [Full Name], f.Origin, f.Destination
FROM Tickets AS t
JOIN Flights AS f ON f.Id = t.FlightId
JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY [Full Name], f.Origin, f.Destination

--08
SELECT FirstName,	LastName,	Age
FROM Tickets AS t
FULL JOIN Passengers AS p ON t.PassengerId = p.Id
WHERE t.Id IS NULL 
ORDER BY  Age DESC, FirstName,	LastName

--09
SELECT p.FirstName + ' ' +p.LastName AS [Full Name],pl.Name, f.Origin+' - '+f.Destination AS Trip, lt.Type
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Flights AS f ON f.Id = t.FlightId
JOIN Planes AS pl ON pl.Id = f.PlaneId
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY [Full Name],pl.Name, Trip, lt.Type

--10
SELECT p.Name , p.Seats,  COUNT(t.Id) AS [Passengers Count]
FROM Planes AS P
LEFT JOIN Flights AS f ON p.Id = f.PlaneId
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY p.Name ,P.Seats
ORDER BY  [Passengers Count] DESC, p.Name, p.Seats



