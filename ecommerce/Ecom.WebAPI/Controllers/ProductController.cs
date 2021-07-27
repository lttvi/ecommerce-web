using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom.Database;
using Ecom.Domain.Models;
using static Ecom.WebAPI.Services.Products.CreateProduct;
using Ecom.WebAPI.Services.Products;

namespace Ecom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]        
        public IActionResult GetProducts()
            => Ok(new GetProducts(_context).Do());
        

        // GET: api/Product/5         
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) =>
            Ok(new GetProduct(_context).Do(id));

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        [HttpPut("test/{id}")]
        public IActionResult TestUpdateProduct(int id) {
            
            return Ok();
        }
            
        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductVMCreate product)
        {
            var category = await _context.Categories.FindAsync(product.CatId);
            var newProduct = new Product
            {
                Name = product.Name,
                Category = category,
                Description = product.Description,
                Price = product.Price
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return Ok(newProduct);    //also work but code 500
        }
        */
        //Test add
        [HttpPost("test")]
        public IActionResult TestAdd(CreateProduct.Request request)
            => Ok(new CreateProduct(_context).Do(request));     


        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
