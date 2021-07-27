using Ecom.Database;
using Ecom.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Categories
{
    public class CreateCategory
    {
        private ApplicationDbContext _context;

        public CreateCategory(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Reponse> Do(Request request)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new Reponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
        public class Request
        {
            [Required]
            [StringLength(30, ErrorMessage = "Name value cannot exceed 30 characters. ")]
            public string Name { get; set; }
            [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters. ")]
            public string? Description { get; set; }
        }
        public class Reponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
        }
    }
}
