using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecom.domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }

    }
}
