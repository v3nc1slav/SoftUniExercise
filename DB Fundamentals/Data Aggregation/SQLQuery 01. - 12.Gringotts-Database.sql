-- PROBLEM 01
SELECT COUNT(Id) AS [Count]
FROM WizzardDeposits; 

-- PROBLEM 02
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits; 

--PROBLEM 03
SELECT DepositGroup,
       MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup; 

-- PROBLEM 04
SELECT DepositGroup
FROM(
SELECT TOP(2) DepositGroup,
			AVG(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup 
ORDER BY DepositGroup DESC) AS MY
ORDER BY DepositGroup

--RROBLEM 05
SELECT DepositGroup,
       SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup; 

--PROBLEM 06
SELECT DepositGroup,
       SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup; 

--PROBLEM 07
SELECT DepositGroup,
       SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE (MagicWandCreator = 'Ollivander family') 
GROUP BY DepositGroup 
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--PROBLEM 08
SELECT DepositGroup, MagicWandCreator, 
		MIN (DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup , MagicWandCreator

--PROBLEM 09
SELECT AgeGroup, COUNT(AgeGroup) AS WizardCount
FROM(
SELECT 
	CASE
		 WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		 WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		 WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		 WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		 WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		 WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		 ELSE '[61+]'
	END AS AgeGroup
FROM WizzardDeposits) AS MY
GROUP BY AgeGroup

--PROBLEM 10
--FIRST SOLUTION
SELECT DISTINCT LEFT(FirstName, 1 ) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter

--PROBLEM 10
--SECAND SOLUTION
SELECT FirstLetter
FROM(
SELECT LEFT(FirstName, 1 ) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest') AS MY
GROUP BY FirstLetter
ORDER BY FirstLetter

--PROBLEM 11
SELECT DepositGroup, IsDepositExpired,
		AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985/01/01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC , IsDepositExpired


--PROBLEM 12
SELECT SUM(Difference)
FROM(
 SELECT DepositAmount -
    (
        SELECT DepositAmount
        FROM WizzardDeposits AS wsd
        WHERE wsd.Id = wd.Id + 1
    ) AS Difference
FROM WizzardDeposits AS wd
)AS MY


