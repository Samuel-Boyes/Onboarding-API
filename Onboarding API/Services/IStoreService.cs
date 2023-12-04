using Onboarding_API.Models;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Services
{
    public interface IStoreService
    {
        Task<int> CreateStore(AddUpdateStoreVM model);
        Task<Store> GetStoreById(int id);
        Task<List<Store>> GetStores();
        Task<Store> UpdateStore(AddUpdateStoreVM model);
        Task DeleteStore(int id);
        bool StoreExists(int id);
    }
}
