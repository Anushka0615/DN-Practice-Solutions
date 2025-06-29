IF OBJECT_ID('Products', 'U') IS NOT NULL
    DROP TABLE Products;
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
GO

INSERT INTO Products VALUES
(1, 'iPhone 15', 'Electronics', 1200.00),
(2, 'Samsung S23', 'Electronics', 1100.00),
(3, 'OnePlus 11', 'Electronics', 900.00),
(4, 'Sony TV', 'Electronics', 1200.00),
(5, 'MacBook Pro', 'Electronics', 2000.00),
(6, 'Nike Shoes', 'Fashion', 150.00),
(7, 'Adidas Hoodie', 'Fashion', 100.00),
(8, 'Puma Shoes', 'Fashion', 150.00),
(9, 'Zara Jacket', 'Fashion', 200.00),
(10, 'Levi’s Jeans', 'Fashion', 100.00);
GO

SELECT 
  Category, ProductName, Price,
  ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products;

SELECT 
  Category, ProductName, Price,
  RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
FROM Products;

SELECT 
  Category, ProductName, Price,
  DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products;

SELECT * FROM (
  SELECT 
    Category, ProductName, Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
  FROM Products
) AS Ranked
WHERE RowNum <= 3;