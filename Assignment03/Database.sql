CREATE DATABASE [PRN221_Assignment3]

USE [PRN221_Assignment3]

-- Creating the 'AppUsers' table
CREATE TABLE AppUsers (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Fullname VARCHAR(255),
    Address VARCHAR(255),
    Email VARCHAR(255) UNIQUE,
    Password VARCHAR(255)
);

-- Creating the 'PostCategories' table
CREATE TABLE PostCategories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(255),
    Description TEXT
);

-- Creating the 'Posts' table
CREATE TABLE Posts (
    PostID INT PRIMARY KEY IDENTITY(1,1),
    AuthorID INT,
    CreatedDate DATETIME,
    UpdatedDate DATETIME,
    Title VARCHAR(255),
    Content TEXT,
    PublishStatus VARCHAR(50),
    CategoryID INT,
    FOREIGN KEY (AuthorID) REFERENCES AppUsers(UserID),
    FOREIGN KEY (CategoryID) REFERENCES PostCategories(CategoryID)
);

-- Inserting data into the 'AppUsers' table
INSERT INTO AppUsers (Fullname, Address, Email, Password)
VALUES ('John Doe', '123 Main St, Anytown, USA', 'john@example.com', 'password123'),
       ('Jane Smith', '456 Oak Ave, Sometown, USA', 'jane@example.com', 'securepwd');

-- Inserting data into the 'PostCategories' table
INSERT INTO PostCategories (CategoryName, Description)
VALUES ('Technology', 'Discussions about the latest tech trends and innovations'),
       ('Travel', 'Explore the world with our travel guides and tips'),
       ('Food', 'Delicious recipes and culinary adventures');

-- Inserting data into the 'Posts' table
INSERT INTO Posts (AuthorID, CreatedDate, UpdatedDate, Title, Content, PublishStatus, CategoryID)
VALUES (1, '2024-03-12 08:00:00', '2024-03-12 08:30:00', 'Introduction to SQL', 'SQL is a powerful language for managing relational databases.', 'Published', 1),
       (2, '2024-03-11 09:15:00', '2024-03-11 10:00:00', 'Top 10 Destinations to Visit', 'Discover the most breathtaking destinations around the globe.', 'Published', 2),
       (1, '2024-03-10 10:30:00', '2024-03-10 11:45:00', 'Spicy Chicken Curry Recipe', 'Learn how to make a delicious and spicy chicken curry.', 'Published', 3);
