using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;
public class Product: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public Guid ProductTypeId { get; set; }
    public Guid BrandId { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public Brand Brand { get; set; }
    public ProductType ProductType { get; set; }
}

