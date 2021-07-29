using Ecom.WebAPI.Services.Categories;
using Ecom.WebAPI.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult TestConnection()
        {
            return Ok("Connected");
        }
        /// <summary>
        /// Category
        /// </summary>
        [HttpGet("get-categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategories());
        }
        [HttpGet("get-category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await _categoryService.GetCategoryById(id));
        }
        [HttpGet("get-category-by-productid/{productId}")]
        public async Task<IActionResult> GetCategoryByProductId(int productId)
        {
            var cat = await _categoryService.GetCategoryByProductId(productId);
            return Ok(cat);
        }        
        
        /// <summary>
        /// Product
        /// </summary>
        [HttpGet("get-products")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetProducts());
        }
        [HttpGet("get-product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(await _productService.GetProductById(id));
        }
        [HttpGet("get-product-by-categoryid/{categoryId}")]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            var product = await _productService.GetProductByCategoryId(categoryId);
            return Ok(product);
        }
        [HttpGet("get-featured")]
        public async Task<IActionResult> GetFreaturedProducts()
        {
            return Ok(await _productService.GetFreaturedProducts());
        }
    }
}
