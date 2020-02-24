using ComicEngine.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ComicEngine.Api.SavedComics {
    public class SavedComicContext : DbContext {
        public DbSet<Comic> Comics { get; set; }

        private readonly IConfiguration _configuration;

        public SavedComicContext (IConfiguration configuration) {
            _configuration = configuration;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder builder) {
            builder.UseSqlServer (_configuration.GetConnectionString ("DefaultConnection"));
        }
    }
}