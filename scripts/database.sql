CREATE DATABASE GetARide

USE GetARide

CREATE TABLE Users (

    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    Email nvarchar(100) NOT NULL, 
    Password nvarchar(200) NOT NULL, 
    Salt nvarchar(100) NOT NULL, 
    Username nvarchar(100) NOT NULL, 
    FullName nvarchar(100), 
    Role nvarchar(100) NOT NULL, 
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NOT NULL
)