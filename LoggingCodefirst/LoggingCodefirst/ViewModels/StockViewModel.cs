using System.ComponentModel;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.ViewModels
{
    public class StockViewModel
    {
        [DisplayName("Store Name")] 
        public int StoreId { get; set; }
        [DisplayName("Product Name")] 
        public int ProductId { get; set; }
        [DisplayName("Quanlity")] 
        public int Quanlity { get; set; }
        [DisplayName("Store Name")] 
        public Store Store { get; set; }
        [DisplayName("Product Name")] 
        public Product Product { get; set; }
    }
}