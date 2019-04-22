CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(250) NOT NULL, 
    [image] BINARY(50) NOT NULL
)
