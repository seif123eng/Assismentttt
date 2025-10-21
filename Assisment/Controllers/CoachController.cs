using Assisment.DTOs;
using Assisment.SpecificRepos.CoachRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachRepo _coachRepo;

        public CoachController(ICoachRepo coachRepo)
        {
            _coachRepo = coachRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() 
        {
            var coaches = await _coachRepo.GetAllCoaches();
            if(coaches == null) return NotFound("None coaches exist");
            var grouprd = coaches.GroupBy(x => x.Specialization);
            return Ok(grouprd);
        }
        //test 
        // test pull
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAllById(int id) 
        {
            var coach = await _coachRepo.GetSpecificId(id);
            if (coach == null) return BadRequest("coach with id {id} not found");
            return Ok(coach);
        }
    }
}
