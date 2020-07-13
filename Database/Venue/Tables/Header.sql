CREATE TABLE [venue].[Header]
(
	 -- Column Definitions
	 [Id] INT IDENTITY(1,1) NOT NULL
	,[Name] VARCHAR(200) NOT NULL
	,[Latitude] DECIMAL(8,8) NOT NULL
	,[Longitude] DECIMAL(8,8) NOT NULL

	 -- Primary Key Constraint
	,CONSTRAINT [pk_venue_header] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
