using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.ViewModels.Categories
{
    public class UpdateCategoryRequest
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
