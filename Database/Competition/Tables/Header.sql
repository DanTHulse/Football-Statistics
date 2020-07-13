CREATE TABLE [competition].[Header]
(
     -- Column Definitions
     [Id] INT IDENTITY(1,1) NOT NULL
    ,[Name] NVARCHAR(200) NOT NULL
    ,[CountryId] INT NOT NULL
    ,[Tier] TINYINT NULL
    ,[IsLeagueCompetition] BIT NOT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_competition_header] PRIMARY KEY CLUSTERED ([Id] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_competition_header_country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country]([Id])

     -- Indexes
    ,INDEX [fki_competition_header_country] NONCLUSTERED ([CountryId] ASC)
);

GO
