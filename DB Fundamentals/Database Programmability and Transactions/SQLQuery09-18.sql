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

-- PROBLEM 13

-- Problem 14

-- PROBLEM 15

CREATE TRIGGER tr_Logs_NotificationEmails ON Logs
FOR INSERT
AS
     BEGIN
         INSERT INTO NotificationEmails
         VALUES
         (
         (
             SELECT AccountId
             FROM inserted
         ),
         CONCAT('Balance change for account: ',
               (
                   SELECT AccountId
                   FROM inserted
               )),
         CONCAT('On ', FORMAT(GETDATE(), 'dd-MM-yyyy HH:mm'), ' your balance was changed from ',
               (
                   SELECT OldSum
                   FROM Logs
               ), ' to ',
               (
                   SELECT NewSum
                   FROM Logs
               ), '.')
         );
     END;

-- PROBLEM 16

CREATE PROCEDURE usp_DepositMoney
(
                 @accountId   INT,
                 @moneyAmount MONEY
)
AS
     BEGIN
         IF(@moneyAmount < 0)
             BEGIN
                 RAISERROR('Cannot deposit negative value', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(@accountId IS NULL
                    OR @moneyAmount IS NULL)
                     BEGIN
                         RAISERROR('Missing value', 16, 1);
                 END;
         END;
         BEGIN TRANSACTION;
         UPDATE Accounts
           SET
               Balance+=@moneyAmount
         WHERE Id = @accountId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Account doesn''t exists', 16, 1);
         END;
         COMMIT;
     END;
-- PROBLEM 17

CREATE PROCEDURE usp_WithdrawMoney
(
                 @accountId   INT,
                 @moneyAmount MONEY
)
AS
     BEGIN
         IF(@moneyAmount < 0)
             BEGIN
                 RAISERROR('Cannot withdraw negative value', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(@accountId IS NULL
                    OR @moneyAmount IS NULL)
                     BEGIN
                         RAISERROR('Missing value', 16, 1);
                 END;
         END;
         BEGIN TRANSACTION;
         UPDATE Accounts
           SET
               Balance-=@moneyAmount
         WHERE Id = @accountId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Account doesn''t exists', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(0 >
                   (
                       SELECT Balance
                       FROM Accounts
                       WHERE Id = @accountId
                   ))
                     BEGIN
                         ROLLBACK;
                         RAISERROR('Balance not enough', 16, 1);
                 END;
         END;
         COMMIT;
     END;

-- PROBLEM 18


CREATE PROCEDURE usp_TransferMoney
(
                 @senderId   INT,
                 @receiverId INT,
                 @amount     MONEY
)
AS
     BEGIN
         IF(@amount < 0)
             BEGIN
                 RAISERROR('Cannot transfer negative amount', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(@senderId IS NULL
                    OR @receiverId IS NULL
                    OR @amount IS NULL)
                     BEGIN
                         RAISERROR('Missing value', 16, 1);
                 END;
         END;

-- Withdraw from the sender
         BEGIN TRANSACTION;
         UPDATE Accounts
           SET
               Balance-=@amount
         WHERE Id = @senderId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Sender''s account doesn''t exists', 16, 1);
         END;

-- Check sender's current balance
         IF(0 >
           (
               SELECT Balance
               FROM Accounts
               WHERE ID = @senderId
           ))
             BEGIN
                 ROLLBACK;
                 RAISERROR('Not enough funds', 16, 1);
         END;

-- Add money to the receiver
         UPDATE Accounts
           SET
               Balance+=@amount
         WHERE ID = @receiverId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Receiver''s account doesn''t exists', 16, 1);
         END;
         COMMIT;
     END;