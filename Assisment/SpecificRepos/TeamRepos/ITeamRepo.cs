using Assisment.DTOs;
using Assisment.GenericRepo;
using Assisment.Models;

namespace Assisment.SpecificRepos.TeamRepos
{
    public interface ITeamRepo : IGeneric<Team>
    {
        public Task<IEnumerable<Non_RegisterDTO>> GetAllNonCompetetion();
    }
}
