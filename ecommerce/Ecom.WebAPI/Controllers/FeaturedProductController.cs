using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom.Database;
using Ecom.Domain.Models;

namespace Ecom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeaturedProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FeaturedProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeaturedProduct>>> GetFeaturedProducts()
        {
            return await _context.FeaturedProducts.ToListAsync();
        }

        // GET: api/FeaturedProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeaturedProduct>> GetFeaturedProduct(int id)
        {
            var featuredProduct = await _context.FeaturedProducts.FindAsync(id);

            if (featuredProduct == null)
            {
                return NotFound();
            }

            return featuredProduct;
        }

        // PUT: api/FeaturedProduct/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeaturedProduct(int id, FeaturedProduct featuredProduct)
        {
            if (id != featuredProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(featuredProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeaturedProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FeaturedProduct
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeaturedProduct>> PostFeaturedProduct(FeaturedProduct featuredProduct)
        {
            _context.FeaturedProducts.Add(featuredProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeaturedProduct", new { id = featuredProduct.Id }, featuredProduct);
        }

        // DELETE: api/FeaturedProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeaturedProduct(int id)
        {
            var featuredProduct = await _context.FeaturedProducts.FindAsync(id);
            if (featuredProduct == null)
            {
                return NotFound();
            }

            _context.FeaturedProducts.Remove(featuredProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeaturedProductExists(int id)
        {
            return _context.FeaturedProducts.Any(e => e.Id == id);
        }
    }
}
