using System.Collections.Generic;
using Moq;
using MultithreadedFinanceDataProcessor.Models;
using MultithreadedFinanceDataProcessor.Services;
using Xunit;

namespace MultithreadedFinanceDataProcessor.Tests
{
    public class TransactionProcessorTests
    {
        [Fact]
        public void ProcessTransactions_ModifiesAmounts()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                new() { Id = "1", Amount = 100, Date = DateTime.Now.ToString(), Category = "Category_1", Description = "Description_Test_Text" },
                new() { Id = "2", Amount = 200, Date = DateTime.Now.ToString(), Category = "Category_1", Description = "Description_Test_Text" },
            };

            var mockCsvReader = new Mock<ICsvReader>();
            mockCsvReader.Setup(m => m.ReadTransactions(It.IsAny<string>())).Returns(transactions);

            var processor = new TransactionProcessor();

            // Act
            processor.ProcessTransactions(transactions);

            // Assert
            Assert.Equal(110, transactions[0].Amount);
            Assert.Equal(220, transactions[1].Amount);
        }
    }
}
