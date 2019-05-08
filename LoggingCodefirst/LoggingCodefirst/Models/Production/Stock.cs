using System.Collections.Generic;
using System.ComponentModel;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.Models.Production
{
    public class Stock
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quanlity { get; set; }
        
        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }
    }
}