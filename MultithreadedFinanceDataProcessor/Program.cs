using MultithreadedFinanceDataProcessor.Services;
using Microsoft.Extensions.DependencyInjection;

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
            .BuildServiceProvider();

        var filePath = args[0];
        var csvReader = serviceProvider.GetService<ICsvReader>();
    }
}