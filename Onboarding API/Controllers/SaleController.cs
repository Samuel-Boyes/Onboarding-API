using Microsoft.AspNetCore.Mvc;
using Onboarding_API.Models;
using Onboarding_API.Services;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _saleService.GetSales());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _saleService.GetSaleById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUpdateSaleVM model)
        {
            return Ok(await _saleService.CreateSale(model));
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Sale sale)
        {
            if (!_saleService.SaleExists(sale.Id))
            {
                return NotFound();
            }
            return Ok(await _saleService.UpdateSale(sale));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_saleService.SaleExists(id))
            {
                return NotFound();
            }
            await _saleService.DeleteSale(id);
            return Ok();
        }



    }
}
