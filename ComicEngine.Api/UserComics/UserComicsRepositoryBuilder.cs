using ComicEngine.Common.Comic;
using ComicEngine.Data;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.UserComics
{
    public class UserComicsRepositoryBuilder
    {
        internal IStorageClient<Comic> StorageClient;
        internal ILogger Logger;

        public UserComicsRepositoryBuilder WithStorageClient(IStorageClient<Comic> storageClient)
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