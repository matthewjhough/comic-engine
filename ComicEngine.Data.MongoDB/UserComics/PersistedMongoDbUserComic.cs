using ComicEngine.Data.UserComics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComicEngine.Data.MongoDb.UserComics
{
    public class PersistedMongoDbUserComic : PersistedUserComic
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public override int Id { get; set; }
    }
}