using Assisment.AppDbContextsss;
using Assisment.DTOs;
using Assisment.GenericRepo;
using Assisment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assisment.SpecificRepos.PlayerRepos
{
    public class PlayerRepo : Generic<Player>, IPlayerRepo
    {
        public PlayerRepo(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<GetYoungestInTeamDTO>> GetYoungestPlayers()
        {
            var teams = await _context.teams.Select(e => new GetYoungestInTeamDTO() 
            {
                Name = e.Name,
                youngest_player = e.players.OrderBy(o => o.age).Select(s => new youngestplayerDTO() 
                {
                    Name = s.Full_name
                }).FirstOrDefault()
            }).ToListAsync();
            if (!teams.Any()) return null;
            return teams;
        }
    }
}
