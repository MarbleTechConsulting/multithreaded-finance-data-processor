namespace MultithreadedFinanceDataProcessor.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
    }
}
