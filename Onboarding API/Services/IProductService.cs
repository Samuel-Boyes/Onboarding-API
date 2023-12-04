using Onboarding_API.Models;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Services
{
    public interface IProductService
    {
        Task<int> CreateProduct(AddUpdateProductVM model);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task<Product> UpdateProduct(AddUpdateProductVM model);
        Task DeleteProduct(int id);
        bool ProductExists(int id);
    }
}
