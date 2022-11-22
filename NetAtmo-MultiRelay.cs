using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Gentilhommiere.NetAtmoMultiRelay
{
    public class NetAtmo_MultiRelay
    {
        private readonly ILogger _logger;

        public NetAtmo_MultiRelay(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<NetAtmo_MultiRelay>();
        }

        [Function("NetAtmo_MultiRelay")]
        public void Run([TimerTrigger("0 */6 * * * *")] MyTimer myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer}");
        }
    }

    public class MyTimer
    {
        public MyScheduleStatus? ScheduleStatus { get; set; }
        public MySchedule? Schedule { get; set; }
        public bool IsPastDue { get; set; }
    }

    public class MySchedule
    {
        public bool AdjustForDST { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }
        public DateTime Next { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
