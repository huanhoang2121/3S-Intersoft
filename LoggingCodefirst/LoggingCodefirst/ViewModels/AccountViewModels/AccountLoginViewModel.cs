using System.ComponentModel;

namespace LoggingCodefirst.ViewModels.AccountViewModels
{
    public class AccountLoginViewModel
    {  
        public string Email { get; set; }  
        public string Password { get; set; }
        
        [DisplayName("Remember Me")] 
        public bool Rememberme { get; set; }
    }
}