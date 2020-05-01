using JobGrabber.Backend.Abstraction;
using JobGrabber.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobGrabber.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService) => _jobService = jobService;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Job>>> Get()
        {
            var jobs = await _jobService.List();
            if (jobs is null)
            {
                return NotFound();
            }

            return Ok(jobs);
        }
    }
}
