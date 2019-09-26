--Problem 12
SELECT CountryName,
       IsoCode AS [ISO Code]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode;

--PROBLEM 13
SELECT Peaks.PeakName, Rivers.RiverName ,
  LOWER(LEFT(Peaks.PeakName, LEN(Peaks.PeakName)-1) + Rivers.RiverName) AS MIX
FROM Peaks 
INNER JOIN Rivers ON RIGHT(Peaks.PeakName, 1) = LEFT(Rivers.RiverName, 1)
ORDER BY Mix;


