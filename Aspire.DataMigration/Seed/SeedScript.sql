-- Insert seed data into the Shopper table
INSERT INTO Shopper (FirstName, LastName, Email)
VALUES ('John', 'Doe', 'john.doe@example.com'),
       ('Jane', 'Smith', 'jane.smith@example.com'),
       ('Emily', 'Jones', 'emily.jones@example.com');

-- Insert seed data into the Product table
INSERT INTO Product (Name, Category, SKU)
VALUES ('Laptop', 'Electronics', 'SKU12345'),
       ('Desktop', 'Electronics', 'SKU12346'),
       ('Monitor', 'Electronics', 'SKU12347');

-- Insert seed data into the ShopAdmin table
INSERT INTO ShopAdmin (FirstName, LastName, Email)
VALUES ('Alice', 'Brown', 'alice.brown@example.com'),
       ('Bob', 'Green', 'bob.green@example.com'),
       ('Charlie', 'Black', 'charlie.black@example.com');
