namespace ModelingJobsWithDataLogEntriesExample
{
    internal class Job
    {
        public string JobNumber { get; set; }
        public List<DataLog> dataLogs { get; set; }

        public Job()
        {
            dataLogs = new List<DataLog>();
        }
    }
}
