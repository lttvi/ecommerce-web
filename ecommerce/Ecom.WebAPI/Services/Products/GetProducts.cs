using Ecom.Database;
using Ecom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Products
{
    public class GetProducts
    {
        private ApplicationDbContext _ctx;

        public GetProducts(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<ProductViewModel> Do() => 
            _ctx.Products.ToList().Select(x => new ProductViewModel
            {
                Name = x.Name,
                Category = x.Category.Name,
                Description = x.Description,
                Price = $"${x.Price.ToString("N2")}", // 1345.24 => 1,345.24
                Comments = x.Comments,
                ProductRating = x.ProductRating, //need check datatype
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate
            });
        

        public class ProductViewModel
        {
            public string Name { get; set; }           
            public string Category { get; set; }           
            public string? Description { get; set; }          
            public string Price { get; set; }
            public List<Comment> Comments { get; set; }
            public decimal? ProductRating { get; set; }           
            public DateTime CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }

        }
    }
}
