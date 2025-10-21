using Assisment.DTOs;
using Assisment.Models;
using Assisment.SpecificRepos.TeamRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepo _teamRepo;

        public TeamController(ITeamRepo teamRepo)
        {
            _teamRepo = teamRepo;
        }

        [HttpPost]
        public async Task<ActionResult> Add(TeamDTO tedto) 
        {
            if (tedto.Name == null || tedto.coachID <= 0 || tedto.city == null) 
                return BadRequest("please enter all data");

            var team = new Team()
            {
                Name = tedto.Name,
                city = tedto.city,
                coachID = tedto.coachID,
            };

            await _teamRepo.AddAsync(team);
            await _teamRepo.SaveAsync();
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult> GetNonRegisters() 
        {
            var teams = await _teamRepo.GetAllNonCompetetion();
            if(teams == null) return NotFound("Not found in sytem");
            return Ok(teams);
        }
    }
}
