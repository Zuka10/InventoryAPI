using Inventory.Domain;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Inventory.Services;

public class ItemService : IItemService
{
    public readonly IMongoCollection<Item> _itemsCollection;

    public ItemService(IOptions<DatabaseSetting> databaseSetting)
    {
        var mongoClient = new MongoClient(databaseSetting.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSetting.Value.DatabaseName);
        _itemsCollection = mongoDatabase.GetCollection<Item>(databaseSetting.Value.CollectionName);
    }

    public async Task CreateAsync(Item item) => await _itemsCollection.InsertOneAsync(item);

    public async Task UpdateAsync(string id, Item updatedItem) => await _itemsCollection.ReplaceOneAsync(i => i.Id == id, updatedItem);

    public async Task RemoveAsync(string id) => await _itemsCollection.DeleteOneAsync(i => i.Id == id);

    public async Task<Item> GetByIdAsync(string id) => await _itemsCollection.Find(i => i.Id == id).FirstOrDefaultAsync();

    public async Task<List<Item>> GetAllAsync() => await _itemsCollection.Find(_ => true).ToListAsync();
}