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

            modelBuilder.Entity<UrlStats>()
                .HasOne(s => s.UrlInfo)
                .WithMany()
                .HasForeignKey(s => s.UrlId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<UrlInfo> UrlInfos { get; set; } = null!;
        public DbSet<UrlStats> UrlStats { get; set; } = null!;
    }
}
