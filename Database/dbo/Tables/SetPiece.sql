CREATE TABLE [dbo].[SetPiece]
(
	 -- Column Definitions
	 [Id] INT IDENTITY(1,1) NOT NULL
	,[Name] VARCHAR(50) NOT NULL

	 -- Primary Key Constraint
	,CONSTRAINT [pk_action] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
