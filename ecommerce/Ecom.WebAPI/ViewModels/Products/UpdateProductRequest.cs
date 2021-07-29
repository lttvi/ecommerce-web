using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.ViewModels.Products
{
    public class UpdateProductRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool isFetured { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}

