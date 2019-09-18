USE Hotel

-- 23 PROBLEM
UPDATE Payments
SET TaxRate = TaxRate-(TaxRate*0.03) 

SELECT TaxRate 
FROM Payments

-- 24 PROBLEM
DELETE Occupancies
