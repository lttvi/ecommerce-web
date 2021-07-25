using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        [Range(0, 100000,
        ErrorMessage = "Value is out of range.")]
        public float? TotalPrice { get; set; }
        public OrderState OrderState { get; set; }
    }
}
