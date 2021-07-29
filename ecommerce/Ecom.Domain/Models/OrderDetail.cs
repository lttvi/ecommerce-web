using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Domain.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        [Range(0, 100000,
        ErrorMessage = "Value is out of range.")]
        public int Quantity { get; set; }
        [Required]
        [Range(0, 100000,
        ErrorMessage = "Value is out of range.")]
        public decimal EstimatedPrice { get; set; }
    }
}
