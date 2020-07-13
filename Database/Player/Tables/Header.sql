CREATE TABLE [player].[Header]
(
	 -- Column Definitions
	 [Id] INT IDENTITY(1,1) NOT NULL
	,[Name] NVARCHAR(200) NOT NULL
	,[DateOfBirth] DATE NULL

	 -- Primary Key Constraint
	,CONSTRAINT [pk_player_header] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
