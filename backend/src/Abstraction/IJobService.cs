using JobGrabber.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobGrabber.Backend.Abstraction
{
    public interface IJobService
    {
        Task<IReadOnlyList<Job>> List();
    }
}