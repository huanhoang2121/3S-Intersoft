using System.ComponentModel;

namespace LoggingCodefirst.ViewModels.User
{
    public class UserEditViewModel
    {
        public int Id { get; set; }
        [DisplayName("Full Name")] 
        public string Fullname { get; set; }
        [DisplayName("Phone Number")]
        public string Phone { get; set; } 
        [DisplayName("Store Name")]
        public int StoreId { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; } 
        [DisplayName("IsActive")]
        public bool IsActive { get; set; }
    }
}