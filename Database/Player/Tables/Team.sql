CREATE TABLE [player].[Team]
(
     -- Column Definitions
     [Id] INT IDENTITY(1,1) NOT NULL
    ,[PlayerId] INT NOT NULL
    ,[TeamId] INT NOT NULL
    ,[TeamNumber] INT NOT NULL
    ,[Active] BIT NOT NULL
    ,[PositionId] INT NOT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_player_team] PRIMARY KEY CLUSTERED ([Id] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_player_team_player_header] FOREIGN KEY ([PlayerId]) REFERENCES [player].[Header]([Id])
    ,CONSTRAINT [fk_player_team_position] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Position]([Id])
    ,CONSTRAINT [fk_player_team_team_header] FOREIGN KEY ([TeamId]) REFERENCES [team].[Header]([Id])

     -- Indexes
    ,INDEX [fki_player_team_player_id] NONCLUSTERED ([PlayerId] ASC)
    ,INDEX [fki_player_team_position_id] NONCLUSTERED ([PositionId] ASC)
    ,INDEX [fki_player_team_team_id] NONCLUSTERED ([TeamId] ASC)
);

GO
