--PROBLEM 09
 CREATE PROC usp_GetHoldersFullName 
 AS
 SELECT a.FirstName + ' ' + a.LastName AS [Full Name]
 FROM AccountHolders AS a

 -- EXEC usp_GetHoldersFullName 

 --PROBLEM 10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThanS( @balance MONEY)
AS
     BEGIN
         SELECT ah.FirstName AS [First Name],
                ah.LastName AS [Last Name]
         FROM AccountHolders AS ah
              JOIN Accounts AS a ON ah.Id = a.AccountHolderId
         GROUP BY ah.FirstName,
                  ah.LastName
         HAVING @balance < SUM(a.Balance)
		 ORDER BY ah.FirstName, ah.LastName
     END;

--PROBLEM 11
CREATE FUNCTION  ufn_CalculateFutureValue
 (
@InitialSum DECIMAL (15,2),
@YearlyInterestRate float,
@NumberOfYears INT
)
RETURNS DECIMAL (18,4)
AS
	BEGIN 
	DECLARE @Result DECIMAL (18,4)
	SET @Result = @InitialSum*(POWER(1+@YearlyInterestRate,@NumberOfYears))
	RETURN @Result
	END;

	EXEC dbo.ufn_CalculateFutureValue 1000, 0.1, 5

--PROBLEM 12
CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@AccountId INT, @YearlyInterestRate float)
AS
	BEGIN
	DECLARE @YearS INT = 5
	SELECT a.Id AS [Account Id], ah.FirstName, ah.LastName, a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue (a.Balance, @YearlyInterestRate, @YearS) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId
	END


	--EXEC dbo.usp_CalculateFutureValueForAccount 1,0.10
