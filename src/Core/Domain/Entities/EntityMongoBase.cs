﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuickOrder.Core.Domain.Entities
{
    public class EntityMongoBase
    {
        public EntityMongoBase()
        {
            this.Id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId Id { get; set; }
    }
}
