using DataImporter.Common.Dto.Base;
using DataImporter.Common.Dto.Competitions;
using DataImporter.Common.Dto.Matches;
using DataImporter.Common.Dto.Players;
using DataImporter.Common.Dto.Teams;
using DataImporter.Common.Dto.Venues;
using Microsoft.EntityFrameworkCore;

namespace LocalImporter
{
    public partial class FutbolContext : DbContext
    {
        public FutbolContext()
        {
        }

        public FutbolContext(DbContextOptions<FutbolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Competition_v1> Competition_v1 { get; set; }
        public virtual DbSet<Match_v1> Match_v1 { get; set; }
        public virtual DbSet<MatchData_v1> MatchData_v1 { get; set; }
        public virtual DbSet<Team_v1> Team_v1 { get; set; }
        public virtual DbSet<Season_v1> Season_v1 { get; set; }


        public virtual DbSet<Competition> Competition { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Edition> CompetitionEdition { get; set; }
        public virtual DbSet<Goal> Goal { get; set; }
        public virtual DbSet<PlayerHeader> PlayerHeader { get; set; }
        public virtual DbSet<MatchHeader> MatchHeader { get; set; }
        public virtual DbSet<CompetitionHeader> CompetitionHeader { get; set; }
        public virtual DbSet<TeamHeader> TeamHeader { get; set; }
        public virtual DbSet<VenueHeader> VenueHeader { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Round> Round { get; set; }
        public virtual DbSet<SetPiece> SetPiece { get; set; }
        public virtual DbSet<PlayerTeam> PlayerTeam { get; set; }
        public virtual DbSet<MatchTeam> MatchTeam { get; set; }
        public virtual DbSet<TeamGoal> TeamGoal { get; set; }
        public virtual DbSet<Venue> MatchVenue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competition_v1>(entity => { });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasOne(d => d.CompetitionEdition)
                    .WithMany(p => p.MatchCompetition)
                    .HasForeignKey(d => d.EditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_competition_competition_edition");

                entity.HasOne(d => d.MatchHeader)
                    .WithOne(p => p.Competition)
                    .HasForeignKey<MatchHeader>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_competition_match_header");

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.MatchCompetition)
                    .HasForeignKey(d => d.RoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_competition_round");
            });

            modelBuilder.Entity<Country>(entity => { });

            modelBuilder.Entity<Edition>(entity =>
            {
                entity.HasOne(d => d.CompetitionHeader)
                    .WithMany(p => p.CompetitionEdition)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_competition_edition_competition_header");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.HasOne(d => d.AssistedByPlayer)
                    .WithMany(p => p.GoalAssistedBy)
                    .HasForeignKey(d => d.AssistedBy)
                    .HasConstraintName("fk_match_goal_player_header_assist");

                entity.HasOne(d => d.ScoredByPlayer)
                    .WithMany(p => p.GoalScoredBy)
                    .HasForeignKey(d => d.ScoredBy)
                    .HasConstraintName("fk_match_goal_player_header_score");

                entity.HasOne(d => d.SetPiece)
                    .WithMany(p => p.MatchGoal)
                    .HasForeignKey(d => d.SetPieceId)
                    .HasConstraintName("fk_match_goal_set_piece");
            });

            modelBuilder.Entity<CompetitionHeader>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CompetitionHeader)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_competition_header_country");
            });

            modelBuilder.Entity<MatchHeader>(entity => { });

            modelBuilder.Entity<PlayerHeader>(entity => { });

            modelBuilder.Entity<TeamHeader>(entity =>
            {
                entity.HasOne(d => d.VenueHeader)
                    .WithMany(p => p.TeamHeader)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("fk_team_header_venue_header");
            });

            modelBuilder.Entity<VenueHeader>(entity => { });

            modelBuilder.Entity<Match_v1>(entity =>
            {
                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.MatchAwayTeam)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_AwayTeamId");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competition_CompetitionId");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchHomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_HomeTeamId");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Season_SeasonId");
            });

            modelBuilder.Entity<MatchData_v1>(entity =>
            {
                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchData)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_MatchId");
            });

            modelBuilder.Entity<Position>(entity => { });

            modelBuilder.Entity<Round>(entity => { });

            modelBuilder.Entity<Season_v1>(entity => { });

            modelBuilder.Entity<SetPiece>(entity => { });

            modelBuilder.Entity<Team_v1>(entity => { });

            modelBuilder.Entity<MatchTeam>(entity =>
            {
                entity.HasOne(d => d.MatchHeader)
                    .WithMany(p => p.MatchTeam)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_team_match_header");

                entity.HasOne(d => d.TeamHeader)
                    .WithMany(p => p.MatchTeam)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_team_team_header");
            });

            modelBuilder.Entity<PlayerTeam>(entity =>
            {
                entity.HasOne(d => d.PlayerHeader)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_player_team_player_header");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_player_team_position");

                entity.HasOne(d => d.TeamHeader)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_player_team_team_header");
            });

            modelBuilder.Entity<TeamGoal>(entity =>
            {
                entity.HasKey(e => new { e.MatchTeamId, e.GoalId })
                    .HasName("pk_match_team_goal");

                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.TeamGoal)
                    .HasForeignKey(d => d.GoalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_team_goal_match_goal");

                entity.HasOne(d => d.MatchTeam)
                    .WithMany(p => p.TeamGoal)
                    .HasForeignKey(d => d.MatchTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_team_goal_match_team");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.HasOne(d => d.MatchHeader)
                    .WithOne(p => p.MatchVenue)
                    .HasForeignKey<MatchHeader>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_venue_match_header");

                entity.HasOne(d => d.VenueHeader)
                    .WithMany(p => p.MatchVenue)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_venue_venue_header");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
