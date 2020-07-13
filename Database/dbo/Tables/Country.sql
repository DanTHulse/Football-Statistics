CREATE TABLE [dbo].[Country]
(
	 -- Column Definitions
	 [Id] INT IDENTITY(1,1) NOT NULL
	,[Name] NVARCHAR(200) NOT NULL
	,[ShortName] VARCHAR(50) NOT NULL

	 -- Primary Key Constraints
	,CONSTRAINT [pk_country] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
