using Assisment.AppDbContextsss;
using Assisment.DTOs;
using Assisment.GenericRepo;
using Assisment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assisment.SpecificRepos.CompetetionRepos
{
    public class CompetetionRepo : Generic<Competition>, ICompetetionRepos
    {
        public CompetetionRepo(AppDbContext context) : base(context)
        {
        }

        public Task<Competition> GetCompetetionById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<competetionDTO>> GetTeamsCount()
        {
            var compettions = await _context.competitions.Select(c => new competetionDTO()
            {
                name = c.title,
                location = c.Location,
                total_participatingTeams = c.teams.Count(),
                team = c.teams.Select(s => new GetNameDTO() 
                {
                    Name = s.Name,
                    total_players = s.players.Count(),
                }).ToList()
            }).ToListAsync();
            return compettions;
        }
    }
}
