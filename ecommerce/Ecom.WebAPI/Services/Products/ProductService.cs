using Ecom.Database;
using Ecom.Domain.Models;
using Ecom.WebAPI.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Products
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProduct(CreateProductRequest request)
        {
            //check if exist
            if (ProductNameExist(request.Name))
            {
                throw new Exception("Product name already exists");
            }

            var cat = _context.Categories.FindAsync(request.CategoryId);
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Category = await cat,
                Price = request.Price,
                isFetured = request.isFetured,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                Comments = new List<Comment>(),
                ProductImages = new List<ProductImage>(),
                ProductRating = null
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception($"No product with id = {id}");
            }
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return product.Id;
        }
        //broken
        public async Task<ProductVM> GetProductByCategoryId(int categoryId)
        {
            //var cat = await _context.Categories.FindAsync(categoryId);
            var query = from cat in _context.Categories
                        where cat.Id == categoryId
                        select cat.SameCatProducts;
            query.Select(x => new ProductVM { 
                
            }).ToList();
            throw new NotImplementedException();
        }

        public async Task<ProductVM> GetProductById(int id)
        {
            return _context.Products.Where(x => x.Id == id).Select(x => new ProductVM
            {
                Id = x.Id,
                Name = x.Name,
                CategoryName = x.Category.Name,
                Description = x.Description,
                Price = x.Price,
                isFetured = x.isFetured,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate
            }).FirstOrDefault();
        }

        public IEnumerable<ProductVM> TestGetProducts()
        {
            return _context.Products.Select(x => new ProductVM
            {
                Id = x.Id,
                Name = x.Name,
                CategoryName = x.Category.Name,
                Description = x.Description
            }).ToList();
        }

        public async Task<int> UpdateProduct(int id, UpdateProductRequest request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception($"No product with id = {id}");
            }
            
            var cat = await _context.Categories.FindAsync(request.CategoryId);
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Category = cat;
            product.ModifiedDate = DateTime.Now;
            product.isFetured = request.isFetured;            

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task<IEnumerable<ProductVM>> GetProducts()
        {
            return _context.Products.Select(x => new ProductVM
            {
                Id = x.Id,
                Name = x.Name,
                CategoryName = x.Category.Name,
                Description = x.Description,
                Price = x.Price,
                isFetured = x.isFetured,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate
            }).ToList();
        }

        public async Task<IEnumerable<ProductVM>> GetFreaturedProducts()
        {
            return _context.Products.Where(x => x.isFetured == true).Select(x => new ProductVM
            {
                Id = x.Id,
                Name = x.Name,
                CategoryName = x.Category.Name,
                Description = x.Description,
                Price = x.Price,
                isFetured = x.isFetured,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate
            }).ToList();
        }

        public async Task<int> UpdateFeaturedAttr(int id, UpdateIsFeaturedAttrRequest request)
        {

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception($"No product with id = {id}");
            }
            var convertString =request.isFetured.ToString().ToLower();
            bool value;
            if (convertString == "true")
            {
                value = true;
            }
            else if (convertString == "true")
            {
                value = false;
            }
            else throw new Exception("Invalid isFeatured value");
            product.isFetured = value;

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return product.Id;
        }

        public bool ProductNameExist(string name)
        {
            return _context.Products.Any(e => e.Name == name);
        }
    }
}
