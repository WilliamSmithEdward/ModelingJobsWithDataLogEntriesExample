namespace ModelingJobsWithDataLogEntriesExample
{
    internal static class JobListExtensions
    {
        public static void OutputToConsole (this List<Job> jobList)
        {
            foreach (var job in jobList)
            {
                Console.WriteLine(job.JobNumber + " " + job.dataLogs.OrderBy(x => x.LogEntryTimeStamp).First().LogData);
            }
        }
    }
}
