
using Ecom.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Categories
{
    public class GetCategory
    {
        private ApplicationDbContext _context;

        public GetCategory(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public CategoryVM Do(int id) => _context.Categories.Where(x => x.Id == id).Select(x => new CategoryVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                SameCatProducts = x.SameCatProducts.Select(y => new ProductVM
                {
                    Id = y.Id,
                    Name = y.Name,
                    Description = y.Description,
                    Price = y.Price,
                    CreatedDate = y.CreatedDate,
                    ModifiedDate = y.ModifiedDate
                })
            }).FirstOrDefault();           
        

        public class CategoryVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
            public IEnumerable<ProductVM> SameCatProducts { get; set; }
        }
        public class ProductVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }
        }
    }
}
