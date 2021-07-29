using Ecom.WebAPI.ViewModels.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductVM>> GetProducts();
        Task<IEnumerable<ProductVM>> GetFreaturedProducts();
        Task<int> UpdateFeaturedAttr(int id, UpdateIsFeaturedAttrRequest request);
        Task<ProductVM1> GetProductById(int id);
        Task<ProductVM> GetProductByCategoryId(int productId);
        Task<int> CreateProduct(CreateProductRequest request);
        Task<int> UpdateProduct(int id, UpdateProductRequest request);
        Task<int> DeleteProduct(int id);
    }
}
