using GoodReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GoodReads.Infrastructure.Persistence
{
    public class GoodReadsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public GoodReadsContext(DbContextOptions<GoodReadsContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
