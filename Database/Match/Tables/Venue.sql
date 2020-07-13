CREATE TABLE [match].[Venue]
(
     -- Column Definitions
     [MatchId] INT NOT NULL
    ,[IsNeutral] BIT NOT NULL
    ,[VenueId] INT NOT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_match_venue] PRIMARY KEY CLUSTERED ([MatchId] ASC, [VenueId] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_match_venue_match_header] FOREIGN KEY ([MatchId]) REFERENCES [match].[Header]([Id])
    ,CONSTRAINT [fk_match_venue_venue_header] FOREIGN KEY ([VenueId]) REFERENCES [venue].[Header]([Id])

     -- Indexes
    ,INDEX [fki_match_venue_match_id] NONCLUSTERED ([MatchId] ASC)
    ,INDEX [fki_match_venue_venue_id] NONCLUSTERED ([VenueId] ASC)
);

GO
