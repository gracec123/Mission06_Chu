using Microsoft.EntityFrameworkCore;

namespace Mission06_Chu.Models
{
    // MovieCollectionContext class represents the DbContext for interacting with the database
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
        {
        }

        public DbSet<Collection> Collections { get; set; }

    }
}
