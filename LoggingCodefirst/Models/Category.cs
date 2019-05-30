﻿using System.Collections.Generic;

namespace LoggingCodefirst.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}