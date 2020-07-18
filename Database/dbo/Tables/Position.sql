CREATE TABLE [dbo].[Position]
(
	 -- Column Definitions
	 [Id] INT IDENTITY(1,1) NOT NULL
	,[Name] VARCHAR(200) NOT NULL

	 -- Primary Key Constraint
	,CONSTRAINT [pk_position] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
