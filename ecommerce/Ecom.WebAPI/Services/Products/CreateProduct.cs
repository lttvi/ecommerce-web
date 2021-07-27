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
        public async Task<Response> Do(Request request)
        {
            var category = await _context.Categories.FindAsync(request.CatId);
            var product = new Product
            {
                Name = request.Name,
                Category = category,
                Description = request.Description,
                Price = request.Price,
                CreatedDate = DateTime.Now
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                CatName = product.Category.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CatName { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }

        public class Request
        {
            public string Name { get; set; }
            public int CatId { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }

        }

    }
}
