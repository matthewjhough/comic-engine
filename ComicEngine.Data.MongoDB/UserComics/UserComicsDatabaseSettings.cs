namespace ComicEngine.Data.MongoDb.UserComics
{
    public class UserComicsDatabaseSettings : IUserComicsDatabaseSettings
    {
        public string UserComicsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUserComicsDatabaseSettings
    {
        string UserComicsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}