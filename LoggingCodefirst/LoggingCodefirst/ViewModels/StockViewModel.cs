using System.ComponentModel;
using LoggingCodefirst.Models;

namespace LoggingCodefirst.ViewModels
{
    public class StockViewModel
    {
        [DisplayName("Store Name")] 
        public int StoreId { get; set; }
        [DisplayName("Product Name")] 
        public int ProductId { get; set; }
        [DisplayName("Quantity")] 
        public int Quantity { get; set; }
        [DisplayName("Store Name")] 
        public Store Store { get; set; }
        [DisplayName("Product Name")] 
        public Product Product { get; set; }
    }
}