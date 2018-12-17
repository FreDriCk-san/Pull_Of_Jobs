namespace PullOfJobs.Jobs
{
    // Numbers are for insurance... They are needed for working with DataBase
    public enum JobType
    {
        Short = 0,
        Medium = 1,
        Long = 2
    }

    public enum Strategy
    {
        Complete = 0,
        Order = 1,
        Error = 2
    }
}
