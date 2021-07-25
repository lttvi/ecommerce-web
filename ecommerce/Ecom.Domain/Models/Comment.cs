using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public int Rating { get; set; }
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters. ")]
        public string? Content { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; } = DateTime.Now;

    }
}
