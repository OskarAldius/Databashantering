-- SQLite
CREATE TABLE Customers(
    Id INTEGER,
    FirstName VARCHAR(30),
    LastName VARCHAR(80),
    Email VARCHAR(128),
    Phone VARCHAR(15)
);

CREATE TABLE Products(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ItemNumber VARCHAR(15) NOT NULL UNIQUE,
    ProductName VARCHAR(60) NOT NULL,
    Description VARCHAR(1024),
    ImageUrl VARCHAR(128),
    Price FLOAT NOT NULL
);

INSERT INTO Products(
    ItemNumber,
    ProductName,
    Price
)VALUES(
    '1001',
    'Hammare',
     399
);



DROP TABLE Products