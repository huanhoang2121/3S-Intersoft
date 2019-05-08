using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LoggingCodefirst.Models.Production;

namespace LoggingCodefirst.ViewModels.ProductViewModels
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("Product Name")] 
        public string ProductName { get; set; }
        [DisplayName("Brand Id")] 
        public int BrandId { get; set; }
        [DisplayName("Category Id")] 
        public int CategoryId { get; set; }
        [DisplayName("Model Year")] 
        public int ModelYear { get; set; }
        [DisplayName("Product Image")] 
        public string ImagePath { get; set; }
        
        [DisplayName("List Price")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal ListPrice { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        [DisplayName("Stocks")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}