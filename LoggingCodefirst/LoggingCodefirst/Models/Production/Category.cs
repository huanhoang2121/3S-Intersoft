using System.Collections.Generic;
using System.ComponentModel;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.Models.Production
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}