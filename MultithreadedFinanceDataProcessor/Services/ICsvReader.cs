using CsvHelper.Configuration;
using MultithreadedFinanceDataProcessor.Models;

namespace MultithreadedFinanceDataProcessor.Services
{
    public interface ICsvReader
    {
        IEnumerable<Transaction> ReadTransactions(string filePath);
    }
}
