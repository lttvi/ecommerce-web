using Ecom.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Categories
{
    public class UpdateCategory
    {
        private ApplicationDbContext _context;

        public UpdateCategory(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
        public async Task<Reponse> Do(int id, Request request)
        {   
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            category.Name = request.Name;
            category.Description = request.Description;

            await _context.SaveChangesAsync();

            var res = new Reponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
            return res;
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
