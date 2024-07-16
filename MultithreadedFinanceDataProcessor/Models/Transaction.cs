namespace MultithreadedFinanceDataProcessor.Models
{
    public class Transaction
    {
        public required string Id { get; set; }
        public required string Date { get; set; }
        public required string Description { get; set; }
        public decimal Amount { get; set; }
        public required string Category { get; set; }
    }
}
