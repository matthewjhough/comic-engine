using ComicEngine.Data.UserComics;

namespace ComicEngine.Data.MongoDb.UserComics
{
    public class UserComicsDatabaseSettings : IUserComicsDatabaseSettings
    {
        public string UserComicsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}