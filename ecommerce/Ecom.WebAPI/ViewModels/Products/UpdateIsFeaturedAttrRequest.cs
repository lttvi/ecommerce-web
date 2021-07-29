using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.ViewModels.Products
{
    public class UpdateIsFeaturedAttrRequest
    {
        [Required]
        public bool isFetured { get; set; }
    }
}
