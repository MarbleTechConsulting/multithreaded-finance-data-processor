using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata;
using CsvHelper;
using CsvHelper.Configuration;
using MultithreadedFinanceDataProcessor.Models;

namespace MultithreadedFinanceDataProcessor.Services
{
    public class CsvReader : ICsvReader
    {
        public IEnumerable<Transaction> ReadTransactions(string filePath, CsvConfiguration csvConfiguration)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvHelper.CsvReader(reader, csvConfiguration);
            return csv.GetRecords<Transaction>();
        }
    }
}
