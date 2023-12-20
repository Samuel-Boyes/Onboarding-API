using Microsoft.AspNetCore.Mvc;
using Onboarding_API.Models;
using Onboarding_API.Services;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerService.GetCustomers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUpdateCustomerVM model)
        {
            return Ok(await _customerService.CreateCustomer(model));
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            if (!_customerService.CustomerExists(customer.Id))
            {
                return NotFound();
            }
            return Ok(await _customerService.UpdateCustomer(customer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_customerService.CustomerExists(id))
            {
                return NotFound();
            }
            await _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
