using Microsoft.EntityFrameworkCore;

using Onboarding_API.Models;
using Onboarding_API.ViewModels;
using OnboardingAPI;

namespace Onboarding_API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly LocalDbContext _context;
        public CustomerService(LocalDbContext context)
        {
            _context = context;
        }

        public bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<int> CreateCustomer(AddUpdateCustomerVM model)
        {
            var customer = new Customer
            {
                Name = model.Name,
                Address = model.Address,
            };
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await this.GetCustomerById(id);
            if (customer != null)
            {
                _context.Remove(customer);
            } else
            {
                throw new Exception("Delete attempt failed, customer with ID: " + id + " does not exist");
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
