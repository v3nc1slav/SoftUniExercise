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

