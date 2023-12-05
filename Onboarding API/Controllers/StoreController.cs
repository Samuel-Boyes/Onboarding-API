using Microsoft.AspNetCore.Mvc;
using Onboarding_API.Models;
using Onboarding_API.Services;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _storeService.GetStores());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _storeService.GetStoreById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUpdateStoreVM model)
        {
            return Ok(await _storeService.CreateStore(model));
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Store store)
        {
            if (!_storeService.StoreExists(store.Id))
            {
                return NotFound();
            }
            return Ok(await _storeService.UpdateStore(store));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Store store)
        {
            if (!_storeService.StoreExists(store.Id))
            {
                return NotFound();
            }
            await _storeService.DeleteStore(store);
            return Ok();
        }


    }
}
