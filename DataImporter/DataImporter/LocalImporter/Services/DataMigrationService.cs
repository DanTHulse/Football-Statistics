using System.Collections.Generic;
using System.Linq;
using DataImporter.Common.Dto.Matches;
using LocalImporter.Repositories.Interfaces;
using LocalImporter.Services.Interfaces;

namespace LocalImporter.Services
{
    public class DataMigrationService : IDataMigrationService
    {
        private readonly IRepository<Match_v1> _matchV1Repo;
        private readonly IRepository<MatchTeam> _matchTeamRepo;

        public DataMigrationService(IRepository<Match_v1> matchV1Repo, IRepository<MatchTeam> matchTeamRepo)
        {
            this._matchV1Repo = matchV1Repo;
            this._matchTeamRepo = matchTeamRepo;
        }

        public void MigrateMatchData()
        {
            // Collect V1 match data
            var matchData = this._matchV1Repo.RetrieveAll();

            // Map to V2 models
            var matchTeams = this.MapMatchTeamData(matchData);

            // Insert into V2 tables
            this._matchTeamRepo.InsertRange(matchTeams);
        }

        private IList<MatchTeam> MapMatchTeamData(IEnumerable<Match_v1> original)
        {
            var homeTeams = original.Select(s => new MatchTeam
            {
                MatchId = s.MatchId,
                TeamId = s.HomeTeamId,
                IsHomeTeam = true
            }).ToList();

            var awayTeams = original.Select(s => new MatchTeam
            {
                MatchId = s.MatchId,
                TeamId = s.AwayTeamId,
                IsHomeTeam = false
            }).ToList();

            homeTeams.AddRange(awayTeams);

            return homeTeams;
        }
    }
}
