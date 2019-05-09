using System.ComponentModel;

namespace LoggingCodefirst.ViewModels
{
    public class UserChangePasswordViewModel
    {
        public int Id { get; set; } 
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}