using Xunit;
using OrderProcessingApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace OrderProcessingApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Loyal_Customer_With_100_Or_More_Receives_10_Percent_Discount()
        {
            var order = new Order { Amount = 100, CustomerType = "Loyal" };
            Assert.Equal(10, order.Discount);  // 10% of 100
            Assert.Equal(90, order.FinalAmount);
        }

        [Fact]
        public void New_Customer_Receives_No_Discount()
        {
            var order = new Order { Amount = 150, CustomerType = "New" };
            Assert.Equal(0, order.Discount); 
            Assert.Equal(150, order.FinalAmount);
        }

        [Fact]
        public void Loyal_Customer_With_Less_Than_100_Gets_No_Discount()
        {
            var order = new Order { Amount = 99, CustomerType = "Loyal" };
            Assert.Equal(0, order.Discount);  
            Assert.Equal(99, order.FinalAmount);
        }

        [Fact]
        public void Negative_Amount_Should_Fail_Validation()
        {
            var order = new Order { Amount = -50, CustomerType = "Loyal" };

            var context = new ValidationContext(order);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(order, context, results, true);

            Assert.False(isValid, "Order amount should not be negative.");
            Assert.Contains(results, r => r.ErrorMessage == "Order amount must be a positive number.");
        }
    }
}
