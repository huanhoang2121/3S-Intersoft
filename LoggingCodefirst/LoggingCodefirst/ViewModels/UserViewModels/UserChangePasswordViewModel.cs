using System.ComponentModel;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.ViewModels.UserViewModels
{
    public class UserChangePasswordViewModel
    {
        public UserChangePasswordViewModel()
        {
            
        }
        
        public UserChangePasswordViewModel(User user)
        {
            Id = user.Id; 
            Email = user.Email; 
            OldPassword = user.Password; 
            NewPassword = user.Password; 
        }

        public int Id { get; set; } 
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("Current Password")]
        public string OldPassword { get; set; }
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
    }
}