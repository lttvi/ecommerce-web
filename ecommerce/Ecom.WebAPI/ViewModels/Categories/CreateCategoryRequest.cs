using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.ViewModels.Categories
{
    public class CreateCategoryRequest
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name value cannot exceed 30 characters. ")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters. ")]
        public string? Description { get; set; }
    }
}
