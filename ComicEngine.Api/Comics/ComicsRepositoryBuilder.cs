using ComicEngine.Common.Comic;
using ComicEngine.Data;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Comics
{
    public class ComicsRepositoryBuilder
    {
        internal IStorageClient<Comic> StorageClient;
        internal ILogger Logger;

        public ComicsRepositoryBuilder WithStorageClient(IStorageClient<Comic> storageClient)
        {
            StorageClient = storageClient;
            return this;
        }

        public ComicsRepositoryBuilder WithLogger(ILogger logger)
        {
            Logger = logger;
            return this;
        }

        public ComicsRepository Build()
        {
            return new ComicsRepository
            {
                ComicStorageClient = StorageClient,
                Logger = Logger
            };
        }
    }
}