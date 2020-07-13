CREATE TABLE [competition].[Edition]
(
     -- Column Definitions
     [Id] INT IDENTITY(1,1) NOT NULL
    ,[CompetitionId] INT NOT NULL
    ,[StartDate] DATE NULL
    ,[EndDate] DATE NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_competition_edition] PRIMARY KEY CLUSTERED ([Id] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_competition_edition_competition_header] FOREIGN KEY ([CompetitionId]) REFERENCES [competition].[Header]([Id])

     -- Indexes
    ,INDEX [fki_competition_edition_competition_id] NONCLUSTERED ([CompetitionId] ASC)
);

GO
