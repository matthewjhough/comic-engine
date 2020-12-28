using ComicEngine.Shared.UserComics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComicEngine.Data.MongoDb.Impl.UserComics
{
    public sealed class PersistedMongoDbUserComic : PersistedResource
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public UserComic UserComic { get; set; }
    }
}