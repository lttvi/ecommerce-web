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
        public async Task<Product> Do(ProductVM product)
        {
            var category = await _context.Categories.FindAsync(product.CatId);
            var newProduct = new Product(product.Name, category, product.Description, product.Price);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public class ProductVM
        {
            public string Name { get; set; }
            public int CatId { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }

        }
    }
}
