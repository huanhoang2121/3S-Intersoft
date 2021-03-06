﻿using System.Collections.Generic;

namespace LoggingCodefirst.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<User> Users { get; set; }

    }
}