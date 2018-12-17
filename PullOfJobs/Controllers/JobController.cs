using Microsoft.AspNetCore.Mvc;
using PullOfJobs.Jobs;
using System.Threading.Tasks;

namespace PullOfJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        // GET: api/Job/id
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            await RequestPool.ExecuteAsync(new JobFactory().SetJob((JobType)id));
            return StatusCode(200, "OK");
        }
    }
}
