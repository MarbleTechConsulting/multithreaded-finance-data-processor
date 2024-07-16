using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MultithreadedFinanceDataProcessor.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the CSV file.");
            return;
        }

        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICsvReader, CsvReader>()
            .AddSingleton<ITransactionProcessor, TransactionProcessor>()
            .AddLogging(configure => configure.AddConsole())
            .BuildServiceProvider();

        var logger = serviceProvider.GetService<ILogger<Program>>();
        if (logger == null)
        {
            Console.WriteLine("Failed to configure logging.");
            return;
        }

        var filePath = args[0];
        var csvReader = serviceProvider.GetService<ICsvReader>();
        if (csvReader == null)
        {
            logger.LogError("Failed to retrieve ICsvReader service.");
            throw new InvalidOperationException("ICsvReader service is not available.");
        }

        var transactions = csvReader.ReadTransactions(filePath);

        var processor = serviceProvider.GetService<ITransactionProcessor>();
        if (processor == null)
        {
            logger.LogError("Failed to retrieve ITransactionProcessor service.");
            throw new InvalidOperationException("ITransactionProcessor service is not available.");
        }

        processor.ProcessTransactions(transactions);
    }
}
