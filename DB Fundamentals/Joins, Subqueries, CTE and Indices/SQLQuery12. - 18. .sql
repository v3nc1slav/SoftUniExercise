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


	


