﻿using System.Collections.Generic;

namespace Ecom.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        public List<Comment> Comments { get; set; }
    }
}