using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebSiteStatus
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient _httpClient;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _httpClient = new HttpClient();

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _httpClient.Dispose();

            _logger.LogInformation("Service has been stopped...");

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await _httpClient.GetAsync("https://www.iamtimcorey.com");
                if (result.IsSuccessStatusCode) 
                {
                    _logger.LogInformation($"Website is up, Status code {result.StatusCode.ToString()} at: {DateTimeOffset.Now}");
                }
                else
                {
                    _logger.LogError($"Website is down, Status code {result.StatusCode.ToString()} at: {DateTimeOffset.Now}");
                }

                await Task.Delay(5*1000, stoppingToken);
            }
        }
    }
}
