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
        private readonly CsvConfiguration _configuration;

        public CsvReader()
        {
            _configuration = new CsvConfiguration()
            {
                // Customize default configuration here
                Delimiter = ",",
                HasHeaderRecord = true,
                CultureInfo = CultureInfo.InvariantCulture
            };
        }

        public IEnumerable<Transaction> ReadTransactions(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvHelper.CsvReader(reader, _configuration);
            return csv.GetRecords<Transaction>();
        }
    }
}
