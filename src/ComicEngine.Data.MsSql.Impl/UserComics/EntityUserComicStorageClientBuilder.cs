namespace ComicEngine.Data.MsSql.Impl.UserComics
{
    public class EntityUserComicStorageClientBuilder
    {
        private UserComicContext _context;

        public EntityUserComicStorageClientBuilder WithComicContext(UserComicContext context)
        {
            _context = context;
            return this;
        }

        public EntityUserComicStorageClient Build()
        {
            return new EntityUserComicStorageClient()
            {
                UserComicContext = _context
            };
        }
    }
}