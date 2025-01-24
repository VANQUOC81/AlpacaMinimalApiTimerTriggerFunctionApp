using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Holoman.Function
{
    // initialize via primary constructor 
    public class KeepAliveFunction(ILoggerFactory loggerFactory)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<KeepAliveFunction>();
        private static readonly HttpClient HttpClient = new();

        [Function("KeepAliveFunction")]
        public async Task Run([TimerTrigger("0 */15 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string apiUrl = "https://az-alpaca-minimal-api.azurewebsites.net/api/alpaca/v1/getclock"; // Replace with your actual API URL

            try
            {
                var response = await HttpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Successfully polled the API at {DateTime.Now}");
                }
                else
                {
                    _logger.LogError($"Failed to poll the API. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred while polling the API: {ex.Message}");
            }

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next.AddMinutes(15)}");
            }
        }
    }
}
