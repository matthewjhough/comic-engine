using ComicEngine.Data;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Actions.Impl.UserComics
{
    public class UserComicsRepositoryBuilder
    {
        internal IStorageClient<UserComic> StorageClient;

        public UserComicsRepositoryBuilder WithStorageClient(IStorageClient<UserComic> storageClient)
        {
            StorageClient = storageClient;
            return this;
        }

        public UserComicsRepository Build()
        {
            return new UserComicsRepository
            {
                ComicStorageClient = StorageClient
            };
        }
    }
}