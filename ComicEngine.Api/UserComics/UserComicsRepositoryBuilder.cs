using ComicEngine.Common.Comics;
using ComicEngine.Common.UserComics;
using ComicEngine.Data;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.UserComics
{
    public class UserComicsRepositoryBuilder
    {
        internal IStorageClient<UserComic> StorageClient;
        internal ILogger Logger;

        public UserComicsRepositoryBuilder WithStorageClient(IStorageClient<UserComic> storageClient)
        {
            StorageClient = storageClient;
            return this;
        }

        public UserComicsRepositoryBuilder WithLogger(ILogger logger)
        {
            Logger = logger;
            return this;
        }

        public UserComicsRepository Build()
        {
            return new UserComicsRepository
            {
                ComicStorageClient = StorageClient,
                Logger = Logger
            };
        }
    }
}