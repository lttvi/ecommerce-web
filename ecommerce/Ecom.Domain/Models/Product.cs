using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters. ")]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters. ")]
        public string? Description { get; set; }
        [Required]
        [Range(0, 100000,
        ErrorMessage = "Value is out of range.")]
        public decimal Price { get; set; }
        public List<Comment> Comments { get; set; }

        public decimal? ProductRating { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } 
        public DateTime? ModifiedDate { get; set; }
        
        public Product()
        {
        }
    }
}
