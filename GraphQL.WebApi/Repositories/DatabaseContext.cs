using GraphQL.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.WebApi.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(now())");

            });
                                       

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(now())");
            });
        }
    }
}
