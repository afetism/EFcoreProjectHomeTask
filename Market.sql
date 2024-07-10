CREATE DATABASE MARKET

USE MARKET 

CREATE TABLE Categories
(
Id INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL CHECK(LEN([Name])>2)
)



CREATE TABLE Products
(
Id INT IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL CHECK(LEN([Name])>2),
[Desc] NVARCHAR(100) NOT NULL CHECK(LEN([Desc])>5),
Category_Id INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
Price DECIMAL(18,2) NOT NULL CHECK(Price>0)

)

-- Categories ?lav? edilm?si
INSERT INTO Categories ([Name])
VALUES 
('Electronics'), 
('Home Appliances'), 
('Books'), 
('Clothing'), 
('Furniture'), 
('Toys'), 
('Sports Equipment'), 
('Beauty Products'), 
('Automotive'), 
('Groceries');

-- Products ?lav? edilm?si
INSERT INTO Products ([Name], [Desc], Category_Id, Price)
VALUES 
('Smartphone', 'Latest model smartphone with 128GB storage', 1, 699.99),
('Laptop', 'High-performance laptop for gaming', 1, 1200.50),
('Television', '50-inch 4K Ultra HD Smart TV', 1, 499.99),
('Refrigerator', 'Energy-efficient refrigerator with freezer', 2, 800.00),
('Microwave', 'Compact microwave oven with grill', 2, 150.75),
('Dishwasher', 'Automatic dishwasher with multiple modes', 2, 650.25),
('Novel', 'Best-selling fiction novel', 3, 19.99),
('Textbook', 'Advanced mathematics textbook', 3, 59.99),
('Cookbook', 'Delicious recipes from around the world', 3, 25.50),
('T-shirt', 'Comfortable cotton T-shirt', 4, 15.99),
('Jeans', 'Stylish denim jeans', 4, 49.99),
('Jacket', 'Warm winter jacket', 4, 89.99),
('Sofa', 'Comfortable 3-seater sofa', 5, 450.00),
('Dining Table', 'Wooden dining table with 6 chairs', 5, 600.00),
('Bed', 'King-size bed with storage', 5, 800.00),
('Action Figure', 'Collectible action figure', 6, 25.99),
('Board Game', 'Fun board game for family', 6, 35.50),
('Puzzle', '1000-piece jigsaw puzzle', 6, 20.75),
('Treadmill', 'Electric treadmill for home use', 7, 700.00),
('Basketball', 'Official size basketball', 7, 29.99),
('Tennis Racket', 'Lightweight tennis racket', 7, 89.50),
('Lipstick', 'Long-lasting matte lipstick', 8, 15.75),
('Shampoo', 'Herbal shampoo for all hair types', 8, 10.99),
('Moisturizer', 'Hydrating facial moisturizer', 8, 25.99),
('Car Battery', 'High-performance car battery', 9, 120.00),
('Tire', 'All-season tire', 9, 80.50),
('Motor Oil', 'Synthetic motor oil', 9, 35.99),
('Apple', 'Fresh organic apples', 10, 3.99),
('Bread', 'Whole grain bread', 10, 2.50),
('Milk', '1-liter organic milk', 10, 1.99);


SELECT *
FROM Categories

SELECT *
FROM Products

