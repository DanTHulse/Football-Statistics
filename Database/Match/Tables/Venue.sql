CREATE TABLE [match].[Venue]
(
     -- Column Definitions
     [Id] INT NOT NULL
    ,[IsNeutral] BIT NOT NULL
    ,[VenueId] INT NOT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_match_venue] PRIMARY KEY CLUSTERED ([Id] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_match_venue_match_header] FOREIGN KEY ([Id]) REFERENCES [match].[Header]([Id])
    ,CONSTRAINT [fk_match_venue_venue_header] FOREIGN KEY ([VenueId]) REFERENCES [venue].[Header]([Id])

     -- Indexes
    ,INDEX [fki_match_venue_match_id] NONCLUSTERED ([Id] ASC)
    ,INDEX [fki_match_venue_venue_id] NONCLUSTERED ([VenueId] ASC)
);

GO
