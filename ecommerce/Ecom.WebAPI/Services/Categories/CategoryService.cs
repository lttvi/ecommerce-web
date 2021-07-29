using Ecom.Database;
using Ecom.Domain.Models;
using Ecom.WebAPI.ViewModels.Categories;
using Ecom.WebAPI.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCategory(CreateCategoryRequest request)
        {
            //check if exist
            if (CatogoryExist(request.Name)) 
            {
                throw new Exception("Category name already exists");
            }
            
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                SameCatProducts = new List<Product>()
            };
            
            _context.Categories.Add(category);
            
            await _context.SaveChangesAsync();
            
            return category.Id;
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) 
            {
                throw new Exception($"No category with id = {id}");
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<CategoryVM>> GetCategories()
        {
            return _context.Categories.Select(x => new CategoryVM {
                Id = x.Id,
                Name = x.Name,
                Description =x.Description
            }).ToList();
        }

        public async Task<CategoryVM> GetCategoryById(int id)
        {
            return _context.Categories.Where(x => x.Id == id).Select(x => new CategoryVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).FirstOrDefault();

        }
        /*
        //test
        public Task<CategoryVM> GetCategoryById(int id)
        {
            var query = from cat in _context.Categories
                      where cat.Id == id
                      select new { cat.Id, cat.Name, cat.Description};
            var category = query.Select(x => new CategoryVM
            { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).FirstOrDefault();
            return category;
        }
        */
        //broken
        public  Task<CategoryVM> GetCategoryByProductId(int productId)
        {

            var p = _context.Products.Where(x => x.Id == productId).Select(x => new ProductVM1
            {
                Id = x.Id,
                Name = x.Name,
                Category = new CategoryVM { 
                    Id = x.Category.Id,
                    Name = x.Category.Name,
                    Description = x.Category.Description
                },
                Description = x.Description,
                Price = x.Price,
                isFetured = x.isFetured,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate
            }).FirstOrDefault();
            throw new Exception();
        }

        public async Task<int> UpdateCategory(int id, UpdateCategoryRequest request)
        {
            var category = await  _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception($"No category with id = {id}");
            }

            category.Name = request.Name;
            category.Description = request.Description;

            _context.Categories.Update(category);

            await _context.SaveChangesAsync();

            return category.Id;
        }

        public bool CatogoryExist(string name) {
            return _context.Categories.Any(e => e.Name == name);
        }

        public Task<CategoryVM1> GetCategoryWithProductsById(int id)
        {

            throw new NotImplementedException();
        }
    }
}
