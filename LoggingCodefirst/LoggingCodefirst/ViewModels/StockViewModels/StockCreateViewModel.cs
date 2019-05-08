using System.ComponentModel;

namespace LoggingCodefirst.ViewModels.StockViewModels
{
    public class StockCreateViewModel
    {
        [DisplayName("Store Name")] 
        public int StoreId { get; set; }
        [DisplayName("Product Name")] 
        public int ProductId { get; set; }
        [DisplayName("Quanlity")] 
        public int Quanlity { get; set; }
    }
}