using JobGrabber.Backend.Abstraction;
using JobGrabber.Backend.JsonPropertyNamePolicies;
using JobGrabber.Backend.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JobGrabber.Backend.Services
{
    public sealed class JobService : IJobService
    {
        private readonly IRedisClient _redisClient;

        public JobService(IRedisClient redisClient) => _redisClient = redisClient;

        public async Task<IReadOnlyList<Job>> List()
        {
            var jobsAsJson = await _redisClient.GetAsync("github");
            return JsonSerializer.Deserialize<List<Job>>(jobsAsJson,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = new SnakeCaseNamingPolicy()
                });
        }
    }
}