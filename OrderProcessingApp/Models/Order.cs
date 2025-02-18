using System.ComponentModel.DataAnnotations;

namespace OrderProcessingApp.Models
{
	public class Order
	{
		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "Order amount must be a positive number.")]
		public decimal Amount { get; set; }

		[Required]
		public string CustomerType { get; set; } = "New";

		public decimal Discount => (Amount >= 100 && CustomerType == "Loyal") ? Amount * 0.10m : 0;
		public decimal FinalAmount => Amount - Discount;
	}
}
