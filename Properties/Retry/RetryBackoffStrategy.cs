using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace EntityApi.Retry
{
   public class RetryBackoffStrategy
    {
        private const int MaxRetryAttempts = 3;
        private const int InitialDelayMilliseconds = 1000;
        private const int MaxDelayMilliseconds = 60000; // Maximum delay of 60 seconds
        private const double Multiplier = 2.0;
        
        private readonly ILogger<RetryBackoffStrategy> _logger; // Injected logger

        // Inject ILogger via constructor
        public RetryBackoffStrategy(ILogger<RetryBackoffStrategy> logger)
        {
            _logger = logger;
        }

        public void RetryWithBackoff()
        {
            int retryAttempts = 0;
            int delay = InitialDelayMilliseconds;

            while (retryAttempts < MaxRetryAttempts)
            {
                try
                {
                    _logger.LogInformation($"Attempt #{retryAttempts + 1}: Performing operation...");
                    PerformOperation();
                    _logger.LogInformation("Operation successful!");
                    return; // Exit method on success
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Attempt #{retryAttempts + 1}: Operation failed.");

                    retryAttempts++;

                    if (retryAttempts >= MaxRetryAttempts)
                    {
                        throw new Exception($"Operation failed after {MaxRetryAttempts} attempts.", ex);
                    }

                    delay = (int)Math.Min(MaxDelayMilliseconds, InitialDelayMilliseconds * Math.Pow(Multiplier, retryAttempts));
                    _logger.LogInformation($"Delaying for {delay / 1000} seconds before next retry...");
                    Thread.Sleep(delay);
                }
            }
        }

        private void PerformOperation()
        {
            // Replace this with your actual operation logic
            throw new Exception("Operation failed.");
        }
    }
    
}
