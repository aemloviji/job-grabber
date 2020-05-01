using System.Threading.Tasks;

namespace JobGrabber.Backend.Abstraction
{
    public interface IRedisClient
    {
        void Connect();
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
    }
}
