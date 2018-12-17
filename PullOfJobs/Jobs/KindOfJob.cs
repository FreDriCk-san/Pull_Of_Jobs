using System.Threading.Tasks;

namespace PullOfJobs.Jobs
{
    // First method, where task is completed 2 times
    public class FirstJob : IJob
    {
        public Strategy Activity { get; } = Strategy.Complete;

        public async Task DoAsync()
        {
            await Task.Delay(5000);
        }
    }


    // Second method, where task is waiting for his order
    public class SecondJob : IJob
    {
        public Strategy Activity { get; } = Strategy.Order;

        public async Task DoAsync()
        {
            await Task.Delay(8000);
        }
    }


    // Third method, where error is thrown
    public class ThirdJob : IJob
    {
        public Strategy Activity { get; } = Strategy.Error;

        public async Task DoAsync()
        {
            await Task.Delay(11000);
        }
    }

}
