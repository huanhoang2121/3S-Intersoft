﻿using System.ComponentModel;

namespace LoggingCodefirst.ViewModels
{
    public class LoginViewModel
    {  
        public string Email { get; set; }  
        public string Password { get; set; }
        public string RequestPath { get; set; }
        
        [DisplayName("Remember Me")] 
        public bool Rememberme { get; set; }
    }
}