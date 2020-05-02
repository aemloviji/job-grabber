using JobGrabber.Backend.Abstraction;
using JobGrabber.Backend.JsonCustomizations;
using JobGrabber.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobGrabber.Backend.Services
{
    public sealed class JobService : IJobService
    {
        private readonly IRedisClient _redisClient;

        public JobService(IRedisClient redisClient) => _redisClient = redisClient;

        public async Task<IReadOnlyList<Job>> List()
        {
            string jobs = await _redisClient.GetAsync("github");
            return JsonSerializerWrapper.Deserialize<List<Job>>(jobs);
        }
    }
}