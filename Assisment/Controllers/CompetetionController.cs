using Assisment.SpecificRepos.CompetetionRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetetionController : ControllerBase
    {
        private readonly ICompetetionRepos _competeionRepo;

        public CompetetionController(ICompetetionRepos competeionRepo)
        {
            _competeionRepo = competeionRepo;
        }

        [HttpDelete]
       public async Task<ActionResult> Delete(int id) 
        {
            var competetion = await _competeionRepo.GetById(id);
            if (competetion == null) return NotFound("Competetion not found");
            await _competeionRepo.DeleteAsync(competetion);
            await _competeionRepo.SaveAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> GetTeamCounts() 
        {
            var comps = await _competeionRepo.GetTeamsCount();
            var grouped = comps.GroupBy(z => z.location);
            return Ok(grouped);
        } 

    }
}
