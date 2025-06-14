using Microsoft.EntityFrameworkCore;
using UrlShortner.Models;

namespace UrlShortner.Data
{
    public class UrlShortnerContext : DbContext
    {
        public UrlShortnerContext(DbContextOptions<UrlShortnerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlInfo>()
                .Property(u => u.Id)
                .UseIdentityColumn();
        }
        public DbSet<UrlInfo> UrlInfos { get; set; } = null!;

    }

}
