CREATE TABLE [match].[Team]
(
     -- Column Definitions
     [Id] INT IDENTITY(1,1) NOT NULL
    ,[MatchId] INT NOT NULL
    ,[TeamId] INT NOT NULL
    ,[Shots] INT NULL
    ,[ShotsOnTarget] INT NULL
    ,[YellowCards] INT NULL
    ,[RedCards] INT NULL
    ,[IsHomeTeam] BIT NOT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_match_team] PRIMARY KEY CLUSTERED ([Id] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_match_team_match_header] FOREIGN KEY ([MatchId]) REFERENCES [match].[Header]([Id])
    ,CONSTRAINT [fk_match_team_team_header] FOREIGN KEY ([TeamId]) REFERENCES [team].[Header]([Id])

     -- Indexes
    ,INDEX [fki_match_team_match_id] NONCLUSTERED ([MatchId] ASC)
    ,INDEX [fki_match_team_team_id] NONCLUSTERED ([TeamId] ASC)
);

GO
