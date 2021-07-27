using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom.Database;
using Ecom.Domain.Models;
using Ecom.WebAPI.Services.Categories;
using static Ecom.WebAPI.Services.Categories.GetCategories;
using Microsoft.AspNetCore.Authorization;

namespace Ecom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public IActionResult GetCategories()
            => Ok(new GetCategories(_context).Do());

        // GET: api/Category/5
        [HttpGet("{id}")]        
        public IActionResult GetCategory(int id)
            => Ok(new GetCategory(_context).Do(id));

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult TestUpdateCategory(int id, UpdateCategory.Request request)
        {   
            if (!CategoryExists(id))
            {
                return NotFound($"No item with id = {id}");
            }
            return Ok(new UpdateCategory(_context).Do(id, request));
        }
        

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }
        //Test post
        [HttpPost("test")]
        public IActionResult CreateCategory(CreateCategory.Request request)
            => Ok(new CreateCategory(_context).Do(request));

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
