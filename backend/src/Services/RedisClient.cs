using JobGrabber.Backend.Abstraction;
using JobGrabber.Backend.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace JobGrabber.Backend.Services
{
    public sealed class RedisClient : IRedisClient
    {
        private readonly ILogger _logger;
        private readonly RedisOptions _options;
        private ConnectionMultiplexer _redis;

        private IDatabaseAsync Database => _redis.GetDatabase();

        public RedisClient(ILogger<RedisClient> logger, IOptions<RedisOptions> options) =>
            (_logger, _options) = (logger, options.Value);

        public void Connect()
        {
            try
            {
                _redis = ConnectionMultiplexer.Connect(_options.Configuration);
            }
            catch (RedisConnectionException ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

            _logger.LogDebug("Connected to Redis.");
        }

        public Task SetAsync(string key, string value) => Database.StringSetAsync(key, value);

        public async Task<string> GetAsync(string key)
        {
            var result = await Database.StringGetAsync(key);
            return result.ToString();
        }
    }
}