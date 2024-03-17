namespace EntityApi.Services
{
    public class DatabaseService
{
    private const int MaxRetryAttempts = 3;
    private const int DelayBetweenRetriesMilliseconds = 1000; // Adjust as needed

    public void WriteToDatabase()
    {
        int retryAttempts = 0;

        while (true)
        {
            try
            {
                // Database write operation
                // Replace this with your actual database write logic
                Console.WriteLine("Writing to database...");

                // Simulate database write operation
                SimulateDatabaseWrite();

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

        internal object PerformOperation()
        {
            throw new NotImplementedException();
        }

        private void SimulateDatabaseWrite()
    {
        // Simulate database write operation
        // Replace this with your actual database write logic
        Random random = new Random();
        if (random.Next(0, 2) == 0)
        {
            throw new Exception("Database write operation failed.");
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