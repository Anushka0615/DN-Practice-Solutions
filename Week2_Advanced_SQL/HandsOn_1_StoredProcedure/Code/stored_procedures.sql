USE EmployeeDB;  -- or EmployeeDB_Test if you're using another name
GO

-- Drop the tables ONLY IF they already exist
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;
GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES 
    (1, 'HR'), 
    (2, 'Finance'), 
    (3, 'IT'), 
    (4, 'Marketing');
GO

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
VALUES 
    ('John', 'Doe', 1, 5000.00, '2020-01-15'),
    ('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
    ('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
    ('Emily', 'Davis', 4, 5500.00, '2021-11-05');
GO

CREATE PROCEDURE sp_GetEmployeesByDepartments
    @DeptID INT
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        d.DepartmentName,
        e.Salary,
        e.JoinDate
    FROM Employees e
    INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DeptID;
END;
GO

EXEC sp_GetEmployeesByDepartment @DeptID = 2;

CREATE PROCEDURE sp_InsertEmployees
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

EXEC sp_InsertEmployee 
    @FirstName = 'Alice', 
    @LastName = 'Walker', 
    @DepartmentID = 3, 
    @Salary = 6500.00, 
    @JoinDate = '2023-06-15';

    SELECT * FROM Employees;