using Ecom.WebAPI.ViewModels.Categories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryVM>> GetCategories();
        Task<CategoryVM> GetCategoryById(int id);
        Task<CategoryVM1> GetCategoryWithProductsById(int id);
        Task<int> CreateCategory(CreateCategoryRequest request);
        Task<int> UpdateCategory(int id, UpdateCategoryRequest request);
        Task<int> DeleteCategory(int id);

    }
}
