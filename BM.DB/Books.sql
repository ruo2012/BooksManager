CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY identity (1,1),
	[Title] nvarchar(200) not null,
	[Author] nvarchar(50) not null,
	[ISBN] nvarchar(20) not null
)
