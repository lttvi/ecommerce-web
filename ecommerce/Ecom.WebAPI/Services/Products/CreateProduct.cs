using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.Database;
using Ecom.Domain.Models;

namespace Ecom.WebAPI.Services.Products
{
    public class CreateProduct
    {
        private ApplicationDbContext _context;

        public CreateProduct(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Do(Product product)
        {
            _context.Products.Add(product);
        }
    }
}
