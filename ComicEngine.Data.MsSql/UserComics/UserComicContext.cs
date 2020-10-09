using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ComicEngine.Data.MsSql.UserComics {
    public class UserComicContext : DbContext {
        public DbSet<PersistedMsSqlUserComic> PersistedComics { get; set; }

        private readonly IConfiguration _configuration;

        public UserComicContext (IConfiguration configuration) {
            _configuration = configuration;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseSqlServer (
                _configuration
                    .GetConnectionString ("DefaultConnection"));
        }
    }
}