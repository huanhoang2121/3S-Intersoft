﻿using System.ComponentModel;
using LoggingCodefirst.Models;

namespace LoggingCodefirst.ViewModels
{
    public class UserEditViewModel
    {
        public int Id { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; } 
        [DisplayName("Full Name")] 
        public string Fullname { get; set; }
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