using Assisment.DTOs;
using Assisment.SpecificRepos.PlayerRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepo _playerRepo;

        public PlayerController(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }
        [HttpPut]
        public async Task<ActionResult> update(int id, PlayerDTO playdto) 
        {
            var player = await _playerRepo.GetById(id);
            if (player == null) return BadRequest($"Player with id {id} not found");

            player.position = playdto.position;
            
            await _playerRepo.UpdateAsync(player);
            await _playerRepo.SaveAsync();
            return Ok($"player with id {id} update his position to {player.position}");
        }

        [HttpGet]
        public async Task<ActionResult> GetYoungetPlayer()
        { 
            var teams = await _playerRepo.GetYoungestPlayers();
            if(teams == null) return NotFound("not teams exists");
            var grouped = teams.GroupBy(p => p.Name);
            return Ok(grouped);

        }
    }
}
