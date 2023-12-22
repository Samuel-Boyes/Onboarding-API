using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
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

        public async Task<List<DetailedSaleVM>> GetDetailedSales()
        {
            var query =
                from sale in _context.Sales
                join customer in _context.Customers on sale.CustomerId equals customer.Id
                join product in _context.Products on sale.ProductId equals product.Id
                join store in _context.Stores on sale.StoreId equals store.Id
                select new DetailedSaleVM{
                    Id = sale.Id,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    CustomerId = customer.Id,
                    CustomerName = customer.Name,
                    StoreId = store.Id,
                    StoreName = store.Name,
                    DateSold = sale.DateSold
                };
            return await query.ToListAsync();
        }

        public async Task<Sale> UpdateSale(Sale sale)
        {
            _context.Update(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
    }
}
