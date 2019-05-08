using System.ComponentModel;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.ViewModels.UserViewModels
{
    public class UserChangePasswordViewModel
    {
        public int Id { get; set; } 
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("Current Password")]
        public string OldPassword { get; set; }
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
    }
}