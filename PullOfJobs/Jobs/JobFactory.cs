namespace PullOfJobs.Jobs
{
    public class JobFactory
    {
        public IJob SetJob(JobType jobType)
        {
            switch (jobType)
            {
                case JobType.Short:
                    return new FirstJob();

                case JobType.Medium:
                    return new SecondJob();

                case JobType.Long:
                    return new ThirdJob();
            }

            return null;
        }

    }
}
