using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Inlamningsuppgift1_DanArv
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        
        private readonly Random _rnd = new Random();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has started.");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has stoped.");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int Temp = _rnd.Next(-15, 45);
                try
                {

                    if (Temp < 10)
                    {
                        _logger.LogInformation($"It's cold outside, dress warm. Temperature is: {Temp} degrees Celsius");
                    }
                    else if (Temp > 30)
                    {
                        _logger.LogInformation($"It's hot outside. The temperature is: {Temp} degrees Celsius");
                    }
                    else
                    {
                        _logger.LogInformation($"The current temperature is: {Temp} degrees Celsius");
                    }

                }
                catch (Exception ex)
                {

                    _logger.LogInformation($"Failed. Could not log temperature - {ex.Message}");
                }

                await Task.Delay(60*1000, stoppingToken);
            }
        }
    }
}
