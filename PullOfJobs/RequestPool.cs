using PullOfJobs.Jobs;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace PullOfJobs
{
    public class RequestPool
    {
        private static ConcurrentDictionary<string, Task> poolOfTasks;

        static RequestPool()
        {
            poolOfTasks = new ConcurrentDictionary<string, Task>();
        }

        public static async Task ExecuteAsync(IJob job)
        {
            if (null == job)
            {
                throw new NullReferenceException("Job is null!");
            }

            var name = job.GetType().FullName;

            if (!poolOfTasks.TryGetValue(name, out var task))
            {
                await CompleteAsync(name, job, task);
                return;
            }

            switch (job.Activity)
            {
                case Strategy.Order:
                    await task;
                    await CompleteAsync(name, job, task);
                    break;

                case Strategy.Complete:
                    await task;
                    break;

                case Strategy.Error:
                    throw new Exception("Wait for executing of another task!");
            }

        }


        private static async Task CompleteAsync(string name, IJob job, Task task)
        {
            task = job.DoAsync();
            poolOfTasks.TryAdd(name, task);
            await task;
            poolOfTasks.TryRemove(name, out var item);
        }
    }
}
