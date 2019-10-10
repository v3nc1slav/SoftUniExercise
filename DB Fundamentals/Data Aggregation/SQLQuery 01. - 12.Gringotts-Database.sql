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
