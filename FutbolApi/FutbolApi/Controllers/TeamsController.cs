using System.Threading.Tasks;
using FutbolApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FutbolApi.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            this._teamService = teamService;
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult> RetrieveTeamById([FromRoute] int teamId)
        {
            var team = await this._teamService.RetrieveTeamById(teamId);

            if (team != null)
            {
                return this.Ok(team);
            }

            return this.NotFound($"No team with the Id: {teamId} was found.");
        }
    }
}
