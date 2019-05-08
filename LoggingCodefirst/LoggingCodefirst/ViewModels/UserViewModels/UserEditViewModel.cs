﻿using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace LoggingCodefirst.ViewModels.UserViewModels
{
    public class UserEditViewModel
    {
        public int Id  { get; set; } 
        [DisplayName("Email Address")]
        public string Email { get; set; } 
        [DisplayName("Full Name")] 
        public string Fullname { get; set; } 
        [DisplayName("Phone Number")]
        public string Phone { get; set; } 
        [DisplayName("Store Name")]
        public int StoreId { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; } 
    }
}