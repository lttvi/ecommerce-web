using Ecom.WebAPI.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.ViewModels.Categories
{
    public class CategoryVM1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ProductVM> SameCatProducts { get; set; }
    }
}
