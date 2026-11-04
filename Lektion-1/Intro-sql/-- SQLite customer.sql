-- SQLite
DROP TABLE Customers;

CREATE TABLE Customers(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName VARCHAR(30) NOT NULL,
    LastName VARCHAR(60) NOT NULL,
    Emil VARCHAR(128) NOT NULL UNIQUE,
    Phone VARCHAR(15)
);

INSERT INTO Customers(
    FirstName,
    LastName,
    Emil
    
)VALUES(
    'Nisse',
    'Hult',
    'nisse2@mail.com'
);

