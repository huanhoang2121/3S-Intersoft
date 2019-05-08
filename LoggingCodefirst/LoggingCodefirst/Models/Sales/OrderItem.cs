using System.ComponentModel;

namespace LoggingCodefirst.Models.Sales
{
    public class OrderItem
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantily { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
    }
}