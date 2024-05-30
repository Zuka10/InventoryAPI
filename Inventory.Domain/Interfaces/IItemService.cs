namespace Inventory.Domain.Interfaces;

public interface IItemService
{
    Task CreateAsync(Item item);
    Task UpdateAsync(string id, Item item);
    Task RemoveAsync(string id);
    Task<Item> GetByIdAsync(string id);
    Task<List<Item>> GetAllAsync();
}