CREATE DATABASE BankingSystem;

USE BankingSystem;

CREATE TABLE Accounts (
    accNo INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    balance DECIMAL(12,2) NOT NULL DEFAULT 0.00
);

CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY AUTO_INCREMENT,
    accNo INT NOT NULL,
    transaction_type ENUM('DEPOSIT', 'WITHDRAW') NOT NULL,
    amount DECIMAL(12,2) NOT NULL,
    transaction_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (accNo)
    REFERENCES Accounts(accNo)
);

-- Create accounts
INSERT INTO Accounts (accNo, name, balance)
VALUES
(1001, 'Bevinto Paul', 5000.00),
(1002, 'Rahul Kumar', 10000.00),
(1003, 'Arun Joseph', 7500.00);

-- Deposit
UPDATE Accounts
SET balance = balance + 2000
WHERE accNo = 1001;

INSERT INTO Transactions (accNo, transaction_type, amount)
VALUES (1001, 'DEPOSIT', 2000);

-- Withdraw
UPDATE Accounts
SET balance = balance - 1000
WHERE accNo = 1001
AND balance >= 1000;

INSERT INTO Transactions (accNo, transaction_type, amount)
VALUES (1001, 'WITHDRAW', 1000);

-- Check balance
SELECT accNo, name, balance
FROM Accounts
WHERE accNo = 1001;

-- Show all accounts
SELECT *
FROM Accounts;

-- Show transaction history
SELECT *
FROM Transactions
WHERE accNo = 1001
ORDER BY transaction_date DESC;

-- Show account + transaction details
SELECT
    a.accNo,
    a.name,
    a.balance,
    t.transaction_type,
    t.amount,
    t.transaction_date
FROM Accounts a
JOIN Transactions t
ON a.accNo = t.accNo
ORDER BY t.transaction_date DESC;
