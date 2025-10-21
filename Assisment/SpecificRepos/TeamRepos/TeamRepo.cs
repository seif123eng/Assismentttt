using Assisment.AppDbContextsss;
using Assisment.DTOs;
using Assisment.GenericRepo;
using Assisment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Assisment.SpecificRepos.TeamRepos
{
    public class TeamRepo : Generic<Team>, ITeamRepo
    {
        public TeamRepo(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Non_RegisterDTO>> GetAllNonCompetetion()
        {
            var teams = await _context.teams.Include(t => t.competitions).Where(e => !e.competitions.Any())
                .Select(e => new Non_RegisterDTO() 
                {
                    Name = e.Name,
                    total_players = e.players.Count(),
                }).OrderByDescending(o => o.total_players).ToListAsync();
            return teams;
        }
    }
}
