using System.Collections.Generic;

namespace LoggingCodefirst.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}