using System.Collections.Generic;
using System.ComponentModel;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.Models.Production
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}