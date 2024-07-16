using System.Collections.Concurrent;
using MultithreadedFinanceDataProcessor.Models;

namespace MultithreadedFinanceDataProcessor.Services
{
    public class TransactionProcessor : ITransactionProcessor
    {
        public void ProcessTransactions(IEnumerable<Transaction> transactions)
        {
            var partitioner = Partitioner.Create(transactions);
            var results = new ConcurrentBag<Transaction>();

            Parallel.ForEach(partitioner, transaction =>
            {
                // Simulate some data processing
                transaction.Amount *= 1.1m; // Just an example modification
                results.Add(transaction);
            });

            // Output the results
            foreach (var result in results)
            {
                Console.WriteLine($"{result.Id} - {result.Date} - {result.Description} - {result.Amount:C} - {result.Category}");
            }
        }
    }
}
