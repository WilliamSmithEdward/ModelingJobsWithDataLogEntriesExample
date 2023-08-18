namespace ModelingJobsWithDataLogEntriesExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Job> jobList = new List<Job>();

            //similate data
            for (int i = 0; i < 2; i++)
            {
                var job = new Job();

                //Simulate job number id
                job.JobNumber = i.ToString();

                for (int j = 0; j < 5; j++)
                {
                    var dataLog = new DataLog();

                    //Simulate log entry time
                    dataLog.LogEntryTimeStamp = DateTime.Now;

                    //Simulate log entry data
                    dataLog.LogData = (RandomNameGenerator.GenerateName(5) + " " + RandomNameGenerator.GenerateName(5)).ToPascalCase();

                    job.dataLogs.Add(dataLog);

                    //Simulate pause between log entries
                    Thread.Sleep(50);
                }

                jobList.Add(job);
            }

            foreach (Job job in jobList)
            {
                Console.WriteLine(job.JobNumber);

                //Sort our job's data log on entry timestamp ascending
                var sortedLogs = job.dataLogs.OrderBy(x => x.LogEntryTimeStamp).ToList();

                //Filter criteria to find first entry (e.g. find employee name)
                var entry = sortedLogs.Where(x => x.LogData.Contains("z", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                Console.WriteLine(string.Join(",", sortedLogs.Select(x => x.LogData)));

                if (entry != null)
                {
                    Console.WriteLine("I found the first occurence of 'z' at log entry timestamped " + entry.LogEntryTimeStamp.ToString() + " " + entry.LogData);
                }
                else
                {
                    Console.WriteLine("'z' was not found in any log entries");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            //Using extension method, our code documents itself! Win!
            jobList.OutputToConsole();
        }
    }
}