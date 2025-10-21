using Assisment.DTOs;
using Assisment.GenericRepo;
using Assisment.Models;

namespace Assisment.SpecificRepos.CoachRepos
{
    public interface ICoachRepo : IGeneric<Coach>
    {
        public Task<IEnumerable<coachDTO>> GetAllCoaches();
        public Task<specificcoachDTO> GetSpecificId(int id);
    }
}
