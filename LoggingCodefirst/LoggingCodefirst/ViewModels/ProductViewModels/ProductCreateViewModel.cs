using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace LoggingCodefirst.ViewModels.ProductViewModels
{
    public class ProductCreateViewModel
    {
        [DisplayName("Product Name")] 
        public string ProductName { get; set; }
        [DisplayName("Brand Id")] 
        public int BrandId { get; set; }
        [DisplayName("Category Id")] 
        public int CategoryId { get; set; }
        [DisplayName("Model Year")] 
        public int ModelYear { get; set; }
        [DisplayName("List Price")]
        public decimal ListPrice { get; set; }
        
        [DisplayName("Product Image")] 
        public string ImagePath { get; set; } 
        [DisplayName("Product Image")] 
        public IFormFile ImageFile { get; set; } 
    }
}