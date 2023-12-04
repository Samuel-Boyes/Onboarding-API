using Microsoft.EntityFrameworkCore;
using Onboarding_API.Models;
using Onboarding_API.ViewModels;
using OnboardingAPI;

namespace Onboarding_API.Services
{
    public class StoreService : IStoreService
    {
        private readonly LocalDbContext _context;
        public StoreService(LocalDbContext context)
        {
            _context = context;
        }
        public bool StoreExists(int id)
        {
            return (_context.Stores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<int> CreateStore(AddUpdateStoreVM model)
        {
            var store = new Store
            {
                Name = model.Name,
                Address = model.Address,
            };
            _context.Add(store);
            await _context.SaveChangesAsync();
            return store.Id;
        }

        public async Task DeleteStore(Store store)
        {
            _context.Remove(store);
            await _context.SaveChangesAsync();
        }

        public async Task<Store?> GetStoreById(int id)
        {
            return await _context.Stores.FindAsync(id);
        }

        public async Task<List<Store>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> UpdateStore(Store store)
        {
            _context.Update(store);
            await _context.SaveChangesAsync();
            return store;
        }
    }
}
