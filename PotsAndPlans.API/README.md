-- To setup local potsandplansdb:

USE master;
GO

IF NOT EXISTS (
        SELECT name
        FROM sys.databases
        WHERE name = N'potsandplansdb'
        )
    CREATE DATABASE [potsandplansdb];
GO

IF SERVERPROPERTY('ProductVersion') > '12'
    ALTER DATABASE [potsandplansdb] SET QUERY_STORE = ON;
GO

-- Create a new table called 'users' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.users', 'U') IS NOT NULL
    DROP TABLE dbo.users;
GO

-- Create the table in the specified schema
CREATE TABLE dbo.users (
    id INT NOT NULL PRIMARY KEY, -- primary key column
    [name] NVARCHAR(50) NOT NULL,
    [username] NVARCHAR(50) NOT NULL,
    [email] NVARCHAR(50) NOT NULL,
    [dateCreated] DATETIME NOT NULL
    );
GO

-- Insert rows into table 'users'
INSERT INTO dbo.users (
    [id],
    [name],
    [username],
    [email],
    [dateCreated]
)
VALUES
    (1, N'Tim', N'claygroundking', N'tim@email.com', CURRENT_TIMESTAMP),
    (2, N'Kim', N'potsoffun', N'kim@email.com', CURRENT_TIMESTAMP),
    (3, N'Jim', N'kilnmesoftly', N'jim@email.com', CURRENT_TIMESTAMP)
GO



-- Create a new table called 'method' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.method', 'U') IS NOT NULL
    DROP TABLE dbo.method;
GO

-- Create the table in the specified schema
CREATE TABLE dbo.method (
    id INT NOT NULL PRIMARY KEY, -- primary key column
    [skill] NVARCHAR(50) NOT NULL,
    );
GO

--Insert rows into table 'method'
INSERT INTO dbo.method (
    [id],
    [skill]
)
VALUES
(1, N'throwing'),
(2, N'handbuilding'),
(3, N'sculpting')
GO

-- Create a new table called 'claybody' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.claybody', 'U') IS NOT NULL
    DROP TABLE dbo.claybody;
GO

-- Create the table in the specified schema
CREATE TABLE dbo.claybody (
    id INT NOT NULL PRIMARY KEY, -- primary key column
    [brand] NVARCHAR(25) NOT NULL,
    [prodname] NVARCHAR(25),
    [prodnum] NVARCHAR(10),
    [cone] INTEGER,
    [firingColor] NVARCHAR(25),
    [texture] NVARCHAR(25)
    );
GO

--Insert rows into table 'claybody'
INSERT INTO dbo.claybody(
    [id],
    [brand],
    [prodname],
    [prodnum],
    [cone],
    [firingColor],
    [texture]
)
VALUES
(1, N'Laguna', N'B-Mix 5', N'WC401', 5, N'White', N'Smooth'),
(2, N'Laguna', N'B-Mix Red', N'WC438', 5, N'Red', N'Slightly Course'),
(3, N'Laguna', N'B-3 Brown', N'WC391', 5, N'Black', N'Slightly Course')
GO

-- Create a new table called 'image' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.image', 'U') IS NOT NULL
    DROP TABLE dbo.image;
GO

-- Create the table in the specified schema
CREATE TABLE dbo.image (
    id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY -- primary key column
)
GO

--Insert rows into table 'image'
INSERT INTO dbo.image(
    [id]
)
VALUES
    (NEWID()), 
    (NEWID()), 
    (NEWID())
GO

-- Create a new table called 'status' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.status', 'U') IS NOT NULL
    DROP TABLE dbo.status;
GO

-- Create the table in the specified schema
CREATE TABLE dbo.status (
    id INT NOT NULL PRIMARY KEY, -- primary key column
    [name] NVARCHAR(20)
)
GO

--Insert rows into table 'status'
INSERT INTO dbo.status(
    [id],
    [name]
)
VALUES
    (1, N'Not Started'),
    (2, N'Wet Clay'),
    (3, N'Leatherhard'),
    (4, N'Drying'),
    (5, N'Greenware'),
    (6, N'Kiln:Bisque'),
    (7, N'Bisqueware'),
    (8, N'Glazing'),
    (9, N'Kiln:Glaze'),
    (10, N'Completed')
GO

-- Create a new table called 'glaze' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.glaze', 'U') IS NOT NULL
    DROP TABLE dbo.glaze;
GO

-- Create the table in the specified schema
CREATE TABLE dbo.glaze (
    id INT NOT NULL PRIMARY KEY, -- primary key column
    [name] NVARCHAR(20) NOT NULL,
    [brand] NVARCHAR(20),
    [prodname] NVARCHAR(20),
    [prodnum] NVARCHAR(20),
    [color] NVARCHAR(20),
    [cone] INT,
    [foodsafe] BIT,
    [directions] NVARCHAR(50)
)
GO

--Insert rows into table 'glaze'
INSERT INTO dbo.glaze(
    [id],
    [name],
    [brand],
    [prodname],
    [prodnum],
    [cone],
    [foodsafe],
    [directions]
)
VALUES
    (1, N'Lazy Glaze', N'homemade', N'', N'', 6, 1, N''),
    (2, N'Clementine', N'Amaco', N'Clementine', N'HF-167', 6, 1, N'Dipping glaze: layering not recommended')
GO

-- Create a new table called 'piece' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.piece', 'U') IS NOT NULL
    DROP TABLE dbo.piece;
GO

-- Create the table in the specified schema
CREATE TABLE dbo.piece (
    id INT NOT NULL PRIMARY KEY, -- primary key column
    [user] INT NOT NULL,
    [name] NVARCHAR(20) NOT NULL,
    [quantity] INT,
    [method] INT NOT NULL,
    [status] INT NOT NULL,
    [claybody] INT,
    [clayweight] NVARCHAR(20),
    [bisquecone] INT,
    [glazecone] INT,
    [bisquefiredate] DATE,
    [glazefiredate] DATE,
    [glazespecs] INT,
    [greenwaredim] NVARCHAR(20),
    [finaldim] NVARCHAR(20),
    [notes] NVARCHAR(100),
    [image] UNIQUEIDENTIFIER
)
GO

--Insert rows into table 'piece'
INSERT INTO dbo.piece(
    [id],
    [user],
    [name],
    [quantity],
    [method],
    [status],
    [claybody],
    [clayweight],
    [bisquecone],
    [glazecone],
    [glazespecs]
)
VALUES
    (1, 1, N'Cat Lady Mug', 4, 2, 3, 1, N'1.8 pounds', 6, 6, 1),
    (2, 2, N'Ramen Bowl', 4, 1, 2, 3, N'2.5 pounds', 6, 6, 2),
    (3, 2, N'Teapot', 1, 1, 1, 2, N'2.5 pounds', 6, 6, 1)
GO