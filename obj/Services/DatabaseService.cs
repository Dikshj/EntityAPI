using System;
using System.Threading;

namespace EntityApi.Services
{
    public class DatabaseService
    {
        private const int MaxRetryAttempts = 3;
        private const int DelayBetweenRetriesMilliseconds = 1000;

        public void PerformOperation()
        {
            // Placeholder logic for database operation
            // Replace this with your actual database write logic
            Console.WriteLine("Performing database operation...");
        }

        public void WriteToDatabase()
        {
            int retryAttempts = 0;

            while (true)
            {
                try
                {
                    // Database write operation
                    PerformOperation(); // Call the actual database operation method

                    Console.WriteLine("Write successful!");
                    break; // Exit loop on success
                }
                catch (Exception ex)
                {
                    retryAttempts++;

                    if (retryAttempts >= MaxRetryAttempts)
                    {
                        Console.WriteLine($"Failed after {MaxRetryAttempts} attempts. Error: {ex.Message}");
                        throw; // Rethrow exception after max attempts
                    }

                    Console.WriteLine($"Retry attempt {retryAttempts}. Error: {ex.Message}");

                    // Backoff delay before next retry (exponential backoff)
                    int delay = (int)Math.Pow(2, retryAttempts) * DelayBetweenRetriesMilliseconds;
                    Console.WriteLine($"Delaying for {delay / 1000} seconds before next retry...");
                    Thread.Sleep(delay);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DatabaseService databaseService = new DatabaseService();
            databaseService.WriteToDatabase();
        }
    }
}
