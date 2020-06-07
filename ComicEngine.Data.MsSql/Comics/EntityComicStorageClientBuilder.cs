namespace ComicEngine.Data.MsSql.Comics
{
    public class EntityComicStorageClientBuilder
    {
        private ComicContext _context;

        public EntityComicStorageClientBuilder WithComicContext(ComicContext context)
        {
            _context = context;
            return this;
        }

        public EntityComicStorageClient Build()
        {
            return new EntityComicStorageClient()
            {
                ComicContext = _context
            };
        }
    }
}