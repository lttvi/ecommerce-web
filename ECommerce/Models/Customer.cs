using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Customer(int id, string username, string password, string name, string email)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.name = name;
            this.email = email;
        }
    }
}
