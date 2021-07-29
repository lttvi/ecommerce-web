using Microsoft.AspNetCore.Mvc;
using Ecom.Database;
using Ecom.WebAPI.Services.Categories;
using System.Threading.Tasks;
using Ecom.WebAPI.ViewModels.Categories;
using Ecom.WebAPI.Services.Products;
using Ecom.WebAPI.ViewModels.Products;
using Ecom.WebAPI.Authentication;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Ecom.WebAPI.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public AdminController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult TestConnection()
        {
            return Ok("Connected");
        }
        [HttpGet("info")]
        public Task<IActionResult> GetCustomerInfo()
        {
            throw new NotImplementedException();
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
        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            return Ok(await _categoryService.CreateCategory(request));
        }
        [HttpPut("update-category/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequest request)
        {
            return Ok(await _categoryService.UpdateCategory(id, request));
        }
        [HttpDelete("detele-category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await _categoryService.DeleteCategory(id));
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
        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            return Ok(await _productService.CreateProduct(request));
        }
        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequest request)
        {
            return Ok(await _productService.UpdateProduct(id, request));
        }
        [HttpDelete("detele-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }
        [HttpPut("update-featured/{id}")]
        public async Task<IActionResult> UpdateFeaturedAttr(int id, UpdateIsFeaturedAttrRequest request)
        {
            return Ok(await _productService.UpdateFeaturedAttr(id, request));
        }
        [HttpGet("get-featured")]
        public async Task<IActionResult> GetFreaturedProducts()
        {
            return Ok(await _productService.GetFreaturedProducts());
        }
    }
}
