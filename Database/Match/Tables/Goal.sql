CREATE TABLE [match].[Goal]
(
     -- Column Definitions
     [Id] INT IDENTITY(1,1) NOT NULL
    ,[ScoredBy] INT NULL
    ,[AssistedBy] INT NULL
    ,[SetPieceId] INT NULL
    ,[TimeScored] INT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_match_goal] PRIMARY KEY CLUSTERED ([Id] ASC)

     -- Foereign Key Constraints
    ,CONSTRAINT [fk_match_goal_player_header_assist] FOREIGN KEY ([AssistedBy]) REFERENCES [player].[Header]([Id])
    ,CONSTRAINT [fk_match_goal_player_header_score] FOREIGN KEY ([ScoredBy]) REFERENCES [player].[Header]([Id])
    ,CONSTRAINT [fk_match_goal_set_piece] FOREIGN KEY ([SetPieceId]) REFERENCES [dbo].[SetPiece]([Id])

     -- Indexes
    ,INDEX [fki_match_goal_assisted_by] NONCLUSTERED ([AssistedBy] ASC)
    ,INDEX [fki_match_goal_scored_by] NONCLUSTERED ([ScoredBy] ASC)
    ,INDEX [fki_match_goal_set_piece_id] NONCLUSTERED ([SetPieceId] ASC)
);

GO
