--PROBLEM 12
SELECT CountryCode, MountainRange, PeakName,Elevation
FROM Peaks AS p
JOIN Mountains AS m ON P.MountainId = M.Id
JOIN MountainsCountries AS mc ON mc.MountainId = M.Id
WHERE MC.CountryCode = 'BG' AND P.Elevation > 2835
ORDER BY P.Elevation DESC

--PROBLEM  13
SELECT CountryCode, COUNT(CountryCode)
FROM MountainsCountries
WHERE CountryCode IN ('BG', 'RU','US')
GROUP BY CountryCode

--PROBLEM 14
SELECT TOP (5) c.CountryName,
               r.RiverName
FROM Countries AS c
     LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
     LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
     JOIN Continents AS cnt ON c.ContinentCode = cnt.ContinentCode
WHERE cnt.ContinentName = 'Africa'
ORDER BY c.CountryName; 

--PROBLEM 15
SELECT MY.ContinentCode, MY.CurrencyCode, MY.CurrencyUsage
FROM
	(
		SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage,
			RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC ) AS MyRank
		FROM  Countries
		GROUP BY CurrencyCode, ContinentCode
		HAVING COUNT(CurrencyCode) > 1
	) AS MY
WHERE MyRank = 1

--PROBLEM 16
SELECT COUNT(*) AS CountryCode
FROM Mountains AS m
JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
RIGHT JOIN Countries AS c ON c.CountryCode = mc.CountryCode
WHERE m.Id IS NULL

--PROBLEM 17
SELECT TOP(5) my.CountryName, my.Elevation, my.Length
FROM(
	SELECT DISTINCT c.CountryName, p.Elevation, r.Length,
	RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC, r.Length DESC, c.CountryName ) AS MyRank
	FROM Countries AS c
	FULL JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	FULL JOIN CountriesRivers AS cr ON cr.CountryCode  = c.CountryCode
	FULL JOIN Peaks AS p ON p.MountainId = mc.MountainId
	FULL JOIN Rivers AS r ON r.Id = cr.RiverId
) AS my
WHERE MyRank = 1
ORDER BY my.Elevation DESC, my.Length DESC, my.CountryName

--PROBLREM 18
SELECT TOP(5) MY.CountryName, MY.HPN [Highest Peak Name],  MY.HPE [Highest Peak Elevation], MY.M [Mountain]
FROM(
SELECT c.CountryName,
	CASE
		WHEN p.PeakName IS NULL THEN '(no highest peak)'
		ELSE p.PeakName 
	END AS HPN, 
	CASE
	  WHEN p.Elevation IS NULL THEN 0
	  ELSE p.Elevation 
	END AS HPE, 
	CASE
	  WHEN m.MountainRange IS NULL THEN '(no mountain)'
	  ELSE m.MountainRange 
	END AS M,
RANK() OVER(PARTITION BY c.CountryName ORDER BY c.CountryName, p.Elevation DESC, p.PeakName ) AS MyRank
FROM Countries AS c
	FULL JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	FULL JOIN Peaks AS p ON p.MountainId = mc.MountainId
	FULL JOIN Mountains AS m ON m.Id = p.MountainId
WHERE c.CountryName  IS NOT NULL
)AS MY
WHERE MyRank = 1

-- PROBLEM 18 
--SECAND
SELECT  TOP (5) c.CountryName,
	CASE
		WHEN p.PeakName IS NULL THEN '(no highest peak)'
		ELSE p.PeakName 
	END AS [Highest Peak Name], 
	CASE
	  WHEN p.Elevation IS NULL THEN 0
	  ELSE p.Elevation 
	END AS [Highest Peak Elevation], 
	CASE
	  WHEN m.MountainRange IS NULL THEN '(no mountain)'
	  ELSE m.MountainRange 
	END AS [Mountain]
FROM Countries AS c
	FULL JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	FULL JOIN Peaks AS p ON p.MountainId = mc.MountainId
	FULL JOIN Mountains AS m ON m.Id = p.MountainId
WHERE c.CountryName  IS NOT NULL
ORDER BY c.CountryName, p.Elevation DESC, p.PeakName 



	


