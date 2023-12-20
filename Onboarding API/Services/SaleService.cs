using Microsoft.EntityFrameworkCore;
using Onboarding_API.Models;
using Onboarding_API.ViewModels;
using OnboardingAPI;

namespace Onboarding_API.Services
{
    public class SaleService : ISaleService
    {
        private readonly LocalDbContext _context;
        public SaleService(LocalDbContext context)
        {
            _context = context;
        }
        public bool SaleExists(int id)
        {
            return (_context.Sales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<int> CreateSale(AddUpdateSaleVM model)
        {
            var sale = new Sale
            {
                ProductId = model.ProductId,
                CustomerId = model.CustomerId,
                StoreId = model.StoreId,
                DateSold = model.DateSold,
            };
            _context.Add(sale);
            await _context.SaveChangesAsync();
            return sale.Id;
        }

        public async Task DeleteSale(int id)
        {
            var sale = await this.GetSaleById(id);
            if (sale != null)
            {
                _context.Remove(sale);
            }
            else
            {
                throw new Exception("Delete attempt failed, sale with ID: " + id + " does not exist");
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Sale?> GetSaleById(int id)
        {
            return await _context.Sales.FindAsync(id);
        }

        public async Task<List<Sale>> GetSales()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> UpdateSale(Sale sale)
        {
            _context.Update(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
    }
}
