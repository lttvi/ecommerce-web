using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.ViewModels.Products
{
    public class CreateProductRequest
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters. ")]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters. ")]
        public string? Description { get; set; }
        [Required]
        [Range(0, 100000, ErrorMessage = "Value is out of range.")]
        public decimal Price { get; set; }
        [Required]
        public bool isFeatured { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
