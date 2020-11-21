namespace ComicEngine.Data.UserComics
{
    public interface IUserComicsDatabaseSettings
    {
        string UserComicsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}