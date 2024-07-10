-- Create the Shopper table
CREATE TABLE Shopper
(
    ShopperID SERIAL PRIMARY KEY,
    FirstName VARCHAR(100)        NOT NULL,
    LastName  VARCHAR(100)        NOT NULL,
    Email     VARCHAR(255) UNIQUE NOT NULL
);

-- Create the Product table
CREATE TABLE Product
(
    ProductID SERIAL PRIMARY KEY,
    Name      VARCHAR(255)        NOT NULL,
    Category  VARCHAR(100)        NOT NULL,
    SKU       VARCHAR(100) UNIQUE NOT NULL
);

-- Create the ShopAdmin table
CREATE TABLE ShopAdmin
(
    AdminID   SERIAL PRIMARY KEY,
    FirstName VARCHAR(100)        NOT NULL,
    LastName  VARCHAR(100)        NOT NULL,
    Email     VARCHAR(255) UNIQUE NOT NULL
);
