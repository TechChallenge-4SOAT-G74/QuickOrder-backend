using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuickOrder.Core.Domain.Entities.Base
{
    public class EntityMongoBase
    {
        public EntityMongoBase()
        {
            Id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId Id { get; set; }
    }
}
