using Inventory.Domain;
using Inventory.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController(IItemService itemService) : ControllerBase
    {
        private readonly IItemService _itemService = itemService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var items = await _itemService.GetAllAsync();
                return Ok(items);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var item = await _itemService.GetByIdAsync(id);
                return Ok(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            try
            {
                await _itemService.CreateAsync(item);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Item item)
        {
            try
            {
                await _itemService.UpdateAsync(id, item);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _itemService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
