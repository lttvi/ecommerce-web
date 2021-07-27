
using Ecom.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Products
{
    public class GetProduct
    {
        private ApplicationDbContext _context;

        public GetProduct(ApplicationDbContext ctx)
        {
            _context = ctx;
        }        
        public ProductVM Do(int id) =>
            _context.Products.Where(x => x.Id == id).Select(x => new ProductVM
            {
                Id = x.Id,
                Name = x.Name,
                Category = new CategoryVM
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                    Description = x.Category.Description
                },
                Description = x.Description,
                Price = x.Price
            }).FirstOrDefault();
        public class CategoryVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
        }
        public class ProductVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public CategoryVM Category { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }
        }
    }
}
