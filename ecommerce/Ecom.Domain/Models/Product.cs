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
       
        public string Name { get; set; }
        public Category Category { get; set; }       
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public bool isFeatured { get; set; }
        public List<Comment> Comments { get; set; }

        public decimal? ProductRating { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } 
        public DateTime? ModifiedDate { get; set; }        
    }
}
