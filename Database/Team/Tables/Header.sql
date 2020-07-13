CREATE TABLE [team].[Header]
(
     -- Column Definitions
     [Id] INT IDENTITY(1,1) NOT NULL
    ,[Name] VARCHAR(200) NOT NULL
    ,[Logo] VARCHAR(1000) NULL
    ,[VenueId] INT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_team_header] PRIMARY KEY CLUSTERED ([Id] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_team_header_venue_header] FOREIGN KEY ([VenueId]) REFERENCES [venue].[Header]([Id])

     -- Indexes
    ,INDEX [fki_team_header_venue_id] NONCLUSTERED ([VenueId] ASC)
);

GO
