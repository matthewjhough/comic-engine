using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ComicEngine.Data.MsSql.Comics {
    public class ComicContext : DbContext {
        public DbSet<PersistedComic> PersistedComics { get; set; }

        private readonly IConfiguration _configuration;

        public ComicContext (IConfiguration configuration) {
            _configuration = configuration;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseSqlServer (
                _configuration
                    .GetConnectionString ("DefaultConnection"));
        }
    }
}