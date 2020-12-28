using ComicEngine.Shared.StorageContainers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComicEngine.Data.MongoDb.Impl.StorageContainers
{
    public class PersistedMongoDbStorageContainer : PersistedResource
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public StorageContainer StorageContainer { get; set; }
    }
}