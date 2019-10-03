--PROBLEM 05
CREATE DATABASE OnlineStore;

CREATE TABLE ItemTypes
(
             ItemTypeID INT NOT NULL,
             Name       VARCHAR(50) NOT NULL,

             CONSTRAINT PK_ItemTypes PRIMARY KEY(ItemTypeId)
);

CREATE TABLE Items
(
             ItemID     INT NOT NULL,
             Name       VARCHAR(50) NOT NULL,
             ItemTypeID INT NOT NULL,

             CONSTRAINT PK_Items PRIMARY KEY(ItemID),
             CONSTRAINT FK_Items_ItemTypes FOREIGN KEY(ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
);

CREATE TABLE Cities
(
             CityID INT NOT NULL,
             Name   VARCHAR(50) NOT NULL,

             CONSTRAINT PK_Cities PRIMARY KEY(CityID)
);

CREATE TABLE Customers
(
             CustomerID INT NOT NULL,
             Name       VARCHAR(50) NOT NULL,
             Birthday   DATE,
             CityID     INT,

             CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
             CONSTRAINT FK_Customers_Cities FOREIGN KEY(CityID) REFERENCES Cities(CityID)
);

CREATE TABLE Orders
(
             OrderID    INT NOT NULL,
             CustomerID INT NOT NULL,

             CONSTRAINT PK_Orders PRIMARY KEY(OrderID),
             CONSTRAINT FK_Orders_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems
(
             OrderID INT NOT NULL,
             ItemID  INT NOT NULL,

             CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID),
             CONSTRAINT FK_OrderItems_Orders FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
             CONSTRAINT FK_OrderItems_Items FOREIGN KEY(ItemID) REFERENCES Items(ItemID)
); 