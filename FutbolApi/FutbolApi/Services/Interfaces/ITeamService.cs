using System.Threading.Tasks;
using FutbolApi.ViewModels;

namespace FutbolApi.Services.Interfaces
{
    public interface ITeamService : IService
    {
        Task<TeamViewModel> RetrieveTeamById(int teamId);
    }
}
