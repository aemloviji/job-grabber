using JobGrabber.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobGrabber.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly RedisService _redisService;

        public JobsController(RedisService redisService) => _redisService = redisService;

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return await _redisService.GetAsync("github");
        }
    }
}
