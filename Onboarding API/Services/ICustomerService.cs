using Onboarding_API.Models;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Services
{
    public interface ICustomerService
    {
        Task<int> CreateCustomer(AddUpdateCustomerVM model);
        Task<Customer?> GetCustomerById(int id);
        Task<List<Customer>> GetCustomers();
        Task<Customer> UpdateCustomer(Customer customer);
        Task DeleteCustomer(int id);
        bool CustomerExists(int id);
    }
}
