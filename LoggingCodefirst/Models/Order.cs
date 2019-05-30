using System;

namespace LoggingCodefirst.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        
        public virtual Customer Customer { get; set; }
    }
}