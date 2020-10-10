using ComicEngine.Common.Comic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComicEngine.Data.MongoDb.UserComics
{
    public sealed class PersistedMongoDbUserComic : PersistedResource
    {
        [BsonId]
        [BsonElement("Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string UserId { get; set; }

        public Comic Comic { get; set; }
    }
}