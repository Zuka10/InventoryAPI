using MongoDB.Bson.Serialization.Attributes;

namespace Inventory.Domain;

public class Item
{
    [BsonId]
    public string Id { get; set; } = null!;
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
}