using Ecom.Domain.Models;
using Ecom.WebAPI.ViewModels.Categories;
using System;

namespace Ecom.WebAPI.ViewModels.Products
{
    public class ProductVM1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryVM Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isFetured { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
