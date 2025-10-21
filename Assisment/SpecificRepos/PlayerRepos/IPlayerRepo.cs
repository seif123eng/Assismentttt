using Assisment.DTOs;
using Assisment.GenericRepo;
using Assisment.Models;

namespace Assisment.SpecificRepos.PlayerRepos
{
    public interface IPlayerRepo : IGeneric<Player>
    {
        public Task<IEnumerable<GetYoungestInTeamDTO>> GetYoungestPlayers();
    }
}
