using System.Collections.Generic;
using MultithreadedFinanceDataProcessor.Models;

namespace MultithreadedFinanceDataProcessor.Services
{
    public interface ITransactionProcessor
    {
        void ProcessTransactions(IEnumerable<Transaction> transactions);
    }
}
