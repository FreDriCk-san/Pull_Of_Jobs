using System.Threading.Tasks;

namespace PullOfJobs.Jobs
{
    public interface IJob
    {
        Strategy Activity { get; }

        Task DoAsync();
    }
}