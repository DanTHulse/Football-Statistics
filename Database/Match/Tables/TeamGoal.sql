CREATE TABLE [match].[TeamGoal]
(
     -- Column Definitions
     [MatchTeamId] INT NOT NULL
    ,[GoalId] INT NOT NULL

     -- Primary Key Constraint
    ,CONSTRAINT [pk_match_team_goal] PRIMARY KEY CLUSTERED ([MatchTeamId] ASC, [GoalId] ASC)

     -- Foreign Key Constraints
    ,CONSTRAINT [fk_match_team_goal_match_goal] FOREIGN KEY ([GoalId]) REFERENCES [match].[Goal]([Id])
    ,CONSTRAINT [fk_match_team_goal_match_team] FOREIGN KEY ([MatchTeamId]) REFERENCES [match].[Team]([Id])

     -- Indexes
    ,INDEX [fki_match_team_goal_goal_id] NONCLUSTERED ([GoalId] ASC)
    ,INDEX [fki_match_team_goal_match_team_id] NONCLUSTERED ([MatchTeamId] ASC)
);

GO
