CREATE TABLE [match].[Header]
(
	 -- Column Definitions
	 [Id] INT IDENTITY(1,1) NOT NULL
	,[MatchDate] DATETIME NULL

	 -- Primary Key Constraint
	,CONSTRAINT [pk_match_header] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
