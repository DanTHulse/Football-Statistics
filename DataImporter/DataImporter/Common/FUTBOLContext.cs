using DataImporter.Common.Dto.Base;
using DataImporter.Common.Dto.Competitions;
using DataImporter.Common.Dto.Matches;
using DataImporter.Common.Dto.Players;
using DataImporter.Common.Dto.Teams;
using DataImporter.Common.Dto.Venues;
using Microsoft.EntityFrameworkCore;

namespace LocalImporter
{
    public partial class FUTBOLContext : DbContext
    {
        public FUTBOLContext()
        {
        }

        public FUTBOLContext(DbContextOptions<FUTBOLContext> options)
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:panopticon.database.windows.net,1433;Initial Catalog=FUTBOL;User ID=danhulse;Password=CloughtAz1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competition_v1>(entity =>
            {
                entity.ToTable("Competition", "football");

                entity.Property(e => e.CompetitionName).IsRequired();

                entity.Property(e => e.Country).HasMaxLength(100);
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasKey(e => new { e.EditionId, e.MatchId })
                    .HasName("pk_match_competition");

                entity.ToTable("Competition", "match");

                entity.HasIndex(e => e.EditionId)
                    .HasName("fki_match_competition_edition_id");

                entity.HasIndex(e => e.MatchId)
                    .HasName("fki_match_competition_match_id");

                entity.HasIndex(e => e.RoundId)
                    .HasName("fki_match_competition_round_id");

                entity.HasOne(d => d.CompetitionEdition)
                    .WithMany(p => p.MatchCompetition)
                    .HasForeignKey(d => d.EditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_competition_competition_edition");

                entity.HasOne(d => d.MatchHeader)
                    .WithMany(p => p.Competition)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_competition_match_header");

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.MatchCompetition)
                    .HasForeignKey(d => d.RoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_match_competition_round");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Edition>(entity =>
            {
                entity.ToTable("Edition", "competition");

                entity.HasIndex(e => e.CompetitionId)
                    .HasName("fki_competition_edition_competition_id");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.CompetitionHeader)
                    .WithMany(p => p.CompetitionEdition)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_competition_edition_competition_header");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.ToTable("Goal", "match");

                entity.HasIndex(e => e.AssistedBy)
                    .HasName("fki_match_goal_assisted_by");

                entity.HasIndex(e => e.ScoredBy)
                    .HasName("fki_match_goal_scored_by");

                entity.HasIndex(e => e.SetPieceId)
                    .HasName("fki_match_goal_set_piece_id");

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
                entity.ToTable("Header", "competition");

                entity.HasIndex(e => e.CountryId)
                    .HasName("fki_competition_header_country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CompetitionHeader)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_competition_header_country");
            });

            modelBuilder.Entity<MatchHeader>(entity =>
            {
                entity.ToTable("Header", "match");

                entity.Property(e => e.MatchDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PlayerHeader>(entity =>
            {
                entity.ToTable("Header", "player");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TeamHeader>(entity =>
            {
                entity.ToTable("Header", "team");

                entity.HasIndex(e => e.VenueId)
                    .HasName("fki_team_header_venue_id");

                entity.Property(e => e.Logo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.VenueHeader)
                    .WithMany(p => p.TeamHeader)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("fk_team_header_venue_header");
            });

            modelBuilder.Entity<VenueHeader>(entity =>
            {
                entity.ToTable("Header", "venue");

                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(8, 8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Match_v1>(entity =>
            {
                entity.ToTable("Match", "football");

                entity.HasIndex(e => new { e.CompetitionId, e.MatchDate, e.HomeTeamId, e.AwayTeamId, e.MatchUid, e.SeasonId })
                    .HasName("IX_Match_SeasonId");

                entity.HasIndex(e => new { e.CompetitionId, e.SeasonId, e.MatchDate, e.AwayTeamId, e.MatchUid, e.HomeTeamId })
                    .HasName("IX_Match_HomeTeamId");

                entity.HasIndex(e => new { e.CompetitionId, e.SeasonId, e.MatchDate, e.HomeTeamId, e.MatchUid, e.AwayTeamId })
                    .HasName("IX_Match_AwayTeamId");

                entity.HasIndex(e => new { e.SeasonId, e.MatchDate, e.HomeTeamId, e.AwayTeamId, e.MatchUid, e.CompetitionId })
                    .HasName("IX_Match_CompetitionId");

                entity.Property(e => e.MatchDate).HasColumnType("datetime");

                entity.Property(e => e.MatchUid).HasMaxLength(100);

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
                entity.ToTable("MatchData", "football");

                entity.Property(e => e.FtawayGoals).HasColumnName("FTAwayGoals");

                entity.Property(e => e.FthomeGoals).HasColumnName("FTHomeGoals");

                entity.Property(e => e.Ftresult)
                    .IsRequired()
                    .HasColumnName("FTResult")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HtawayGoals).HasColumnName("HTAwayGoals");

                entity.Property(e => e.HthomeGoals).HasColumnName("HTHomeGoals");

                entity.Property(e => e.Htresult)
                    .HasColumnName("HTResult")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchData)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_MatchId");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Round>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Season_v1>(entity =>
            {
                entity.ToTable("Season", "football");

                entity.Property(e => e.SeasonPeriod)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<SetPiece>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team_v1>(entity =>
            {
                entity.ToTable("Team", "football");

                entity.Property(e => e.TeamName).IsRequired();
            });

            modelBuilder.Entity<MatchTeam>(entity =>
            {
                entity.ToTable("Team", "match");

                entity.HasIndex(e => e.MatchId)
                    .HasName("fki_match_team_match_id");

                entity.HasIndex(e => e.TeamId)
                    .HasName("fki_match_team_team_id");

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
                entity.ToTable("Team", "player");

                entity.HasIndex(e => e.PlayerId)
                    .HasName("fki_player_team_player_id");

                entity.HasIndex(e => e.PositionId)
                    .HasName("fki_player_team_position_id");

                entity.HasIndex(e => e.TeamId)
                    .HasName("fki_player_team_team_id");

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

                entity.ToTable("TeamGoal", "match");

                entity.HasIndex(e => e.GoalId)
                    .HasName("fki_match_team_goal_goal_id");

                entity.HasIndex(e => e.MatchTeamId)
                    .HasName("fki_match_team_goal_match_team_id");

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
                entity.HasKey(e => new { e.MatchId, e.VenueId })
                    .HasName("pk_match_venue");

                entity.ToTable("Venue", "match");

                entity.HasIndex(e => e.MatchId)
                    .HasName("fki_match_venue_match_id");

                entity.HasIndex(e => e.VenueId)
                    .HasName("fki_match_venue_venue_id");

                entity.HasOne(d => d.MatchHeader)
                    .WithMany(p => p.MatchVenue)
                    .HasForeignKey(d => d.MatchId)
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
