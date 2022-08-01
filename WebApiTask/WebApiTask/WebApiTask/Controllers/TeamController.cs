using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiTask.Models;
using WebApiTask.Services;


namespace WebApiTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_teamService.GetAllTeams());
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_teamService.GetTeamById(id));
        }
        [HttpPost]
        public IActionResult Create(string teamName)
        {
            return Ok(_teamService.CreateTeam(new Team() { Name = teamName }));
        }
        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, string teamName)
        {
            var team = _teamService.GetTeamById(id);
            if (team == null)
            {
                return BadRequest();
            }
            team.Name = teamName;
            return Ok(_teamService.UpdateTeam(team));
        }
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var team = _teamService.GetTeamById(id);
            if (team == null)
            {
                return BadRequest();
            }
            _teamService.DeleteTeam(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddPlayerToTeam(Guid teamId, Guid playerId)
        {
            var team = _teamService.GetTeamById(teamId);
            if (team == null)
            {
                return BadRequest();
            }

            _teamService.AddPlayerToTeam(teamId, playerId);
            return Ok();
        }
        [HttpPost]
        public IActionResult RemovePlayerFromTeam(Guid teamId, Guid playerId)
        {
            var team = _teamService.GetTeamById(teamId);
            if (team == null)
            {
                return BadRequest();
            }

            _teamService.RemovePlayerFromTeam(teamId, playerId);
            return Ok();
        }

    }
}
