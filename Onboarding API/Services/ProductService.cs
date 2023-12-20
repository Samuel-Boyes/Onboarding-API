using Microsoft.EntityFrameworkCore;
using Onboarding_API.Models;
using Onboarding_API.ViewModels;
using OnboardingAPI;

namespace Onboarding_API.Services
{
    public class ProductService : IProductService
    {
        private readonly LocalDbContext _context;
        public ProductService(LocalDbContext context)
        {
            _context = context;
        }
        public bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<int> CreateProduct(AddUpdateProductVM model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await this.GetProductById(id);
            if (product != null)
            {
                _context.Remove(product);
            }
            else
            {
                throw new Exception("Delete attempt failed, product with ID: " + id + " does not exist");
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
