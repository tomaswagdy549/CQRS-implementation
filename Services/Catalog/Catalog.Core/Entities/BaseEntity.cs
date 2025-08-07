using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;
public class BaseEntity
{
    public Guid Id { get; set; }
}
