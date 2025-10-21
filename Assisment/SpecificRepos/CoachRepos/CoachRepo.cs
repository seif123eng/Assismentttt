using Assisment.AppDbContextsss;
using Assisment.DTOs;
using Assisment.GenericRepo;
using Assisment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assisment.SpecificRepos.CoachRepos
{
    public class CoachRepo : Generic<Coach>, ICoachRepo
    {
        public CoachRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<coachDTO>> GetAllCoaches()
        {
            var coaches = await _context.coaches.Select(e => new coachDTO() 
            {
                Id = e.Id,
                Name = e.Name,
                Specialization = e.Specialization,
                team = new 
                {
                    team_name = e.team.Name,
                    city = e.team.city
                }
            }).ToListAsync();
            if (!coaches.Any() || coaches == null) return null;
            return coaches;
        }

        public async Task<specificcoachDTO> GetSpecificId(int id)
        {
            var coach = await _context.coaches.Select(e => new specificcoachDTO()
            {
                Id = e.Id,
                Name = e.Name,
                team = new
                {
                    name = e.team.Name,
                    city = e.team.city
                },
                total_players = e.team.players.Count()
            }).FirstOrDefaultAsync(i =>i.Id == id);
            if (coach == null) return null;
            return coach;
        }
        
    }
}
