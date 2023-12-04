using Onboarding_API.Models;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Services
{
    public interface ISaleService
    {
        Task<int> CreateSale(AddUpdateSaleVM model);
        Task<Sale> GetSaleById(int id);
        Task<List<Sale>> GetSales();
        Task<Sale> UpdateSale(Sale sale);
        Task DeleteSale(Sale sale);
        bool SaleExists(int id);
    }
}
