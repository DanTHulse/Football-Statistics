CREATE TABLE [dbo].[Round]
(
	 -- Column Definitions
	 [Id] INT IDENTITY(1,1) NOT NULL
	,[Name] VARCHAR(50) NOT NULL

	 -- Primary Key Constraints
	,CONSTRAINT [pk_round] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
