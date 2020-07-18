using Common.Dto.Competitions;
using Common.Dto.Lookups;
using Common.Dto.Matches;
using Common.Dto.Players;
using Common.Dto.Teams;
using Common.Dto.Venues;
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
                entity.Property(a => a.Id)
                    .UseIdentityColumn(1, 1);

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

                entity.HasOne(d => d.TeamGoal)
                    .WithOne(p => p.Goal)
                    .HasForeignKey<TeamGoal>(d => d.GoalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_team_goal_match_goal");
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

            modelBuilder.Entity<Position>(entity => { });

            modelBuilder.Entity<Round>(entity => { });

            modelBuilder.Entity<SetPiece>(entity => { });

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
