--PROBLEM 09
SELECT Mountains.MountainRange , Peaks.PeakName, Peaks.Elevation
FROM Peaks
	JOIN Mountains ON Peaks.MountainId = Mountains.ID
WHERE Mountains.MountainRange = 'Rila'
ORDER BY Peaks.Elevation DESC;

