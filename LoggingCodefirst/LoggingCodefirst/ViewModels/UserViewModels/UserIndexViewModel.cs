using System.ComponentModel;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.ViewModels.UserViewModels
{
    public class UserIndexViewModel
    {
        public int Id { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; } 
        [DisplayName("Full Name")] 
        public string Fullname { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }  
        [DisplayName("Phone Number")]
        public string Phone { get; set; } 
        [DisplayName("Address")]
        public string Address { get; set; } 
        [DisplayName("IsActive")]
        public bool IsActive { get; set; }

        [DisplayName("Store Name")]
        public int StoreId { get; set; }
        [DisplayName("Store Name")]
        public virtual Store Store { get; set; }
    }
}