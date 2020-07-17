using System.Threading.Tasks;
using DataImporter.Common.Dto.Teams;
using FutbolApi.Services.Interfaces;
using FutbolApi.ViewModels;
using LocalImporter.Repositories.Interfaces;

namespace FutbolApi.Services
{
    public class TeamService : ITeamService
    {
        private readonly IEntityRead<TeamHeader> _teamRead;

        public TeamService(IEntityRead<TeamHeader> teamRead)
        {
            this._teamRead = teamRead;
        }

        public Task<TeamViewModel> RetrieveTeamById(int teamId)
        {
            return this._teamRead.RetrieveFirst(s => s.Id == teamId, s => new TeamViewModel
            {
                TeamId = s.Id,
                TeamLogo = s.Logo,
                TeamName = s.Name
            });
        }
    }
}
