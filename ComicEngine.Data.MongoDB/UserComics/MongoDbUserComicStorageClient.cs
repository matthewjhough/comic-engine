using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;

namespace ComicEngine.Data.MongoDb.UserComics
{
    public class MongoDbUserComicStorageClient : IStorageClient<Comic>
    {
        public Task Create(Comic resource, string subject)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Comic>> Get(string subject)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(string resourceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Comic> Update(string resourceId, Comic resource)
        {
            throw new System.NotImplementedException();
        }
    }
}