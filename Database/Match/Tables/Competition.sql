CREATE TABLE [match].[Competition]
(
     -- Column Definitions
     [EditionId] INT NOT NULL
    ,[MatchId] INT NOT NULL
    ,[RoundId] INT NOT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_match_competition] PRIMARY KEY CLUSTERED ([EditionId] ASC, [MatchId] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_match_competition_competition_edition] FOREIGN KEY ([EditionId]) REFERENCES [competition].[Edition]([Id])
    ,CONSTRAINT [fk_match_competition_match_header] FOREIGN KEY ([MatchId]) REFERENCES [match].[Header]([Id])
    ,CONSTRAINT [fk_match_competition_round] FOREIGN KEY ([RoundId]) REFERENCES [dbo].[Round]([Id])

     -- Indexes
    ,INDEX [fki_match_competition_edition_id] NONCLUSTERED ([EditionId] ASC)
    ,INDEX [fki_match_competition_match_id] NONCLUSTERED ([MatchId] ASC)
    ,INDEX [fki_match_competition_round_id] NONCLUSTERED ([RoundId] ASC)
);

GO
