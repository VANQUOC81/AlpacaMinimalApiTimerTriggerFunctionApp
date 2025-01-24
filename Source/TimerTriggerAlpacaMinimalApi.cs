using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Holoman.Function
{
    // initialize via primary constructor 
    public class TimerTriggerAlpacaMinimalApi(ILoggerFactory loggerFactory)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<TimerTriggerAlpacaMinimalApi>();

        [Function("TimerTriggerAlpacaMinimalApi")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
