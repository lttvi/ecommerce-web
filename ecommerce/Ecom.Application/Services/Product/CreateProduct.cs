using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.Database;
using Ecom.Domain.Models;

namespace Ecom.WebAPI.Services
{
    public class CreateProduct
    {
        private ApplicationDbContext _context;

        public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Do(string name, Category cat, string des, decimal price)
        {            
            _context.Products.Add(new Product(name, cat, des, price));
            
        }
    }
}
