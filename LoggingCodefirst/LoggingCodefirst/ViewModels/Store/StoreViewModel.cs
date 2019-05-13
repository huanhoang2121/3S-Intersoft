using System.Collections.Generic;
using System.ComponentModel;
using LoggingCodefirst.Models;

namespace LoggingCodefirst.ViewModels.Store
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        [DisplayName("Store Name")]
        public string StoreName { get; set; } 
        [DisplayName("Phone Number")]
        public string Phone { get; set; } 
        [DisplayName("Email Address")] 
        public string Email { get; set; }
        [DisplayName("Street")]
        public string Street { get; set; }  
        [DisplayName("City")]
        public string City { get; set; } 
        [DisplayName("State")]
        public string State { get; set; } 
        [DisplayName("ZipCode")]
        public string ZipCode { get; set; }  

        [DisplayName("Stocks")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}