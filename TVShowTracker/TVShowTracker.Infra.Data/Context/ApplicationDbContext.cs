using Microsoft.EntityFrameworkCore;
using TVShowTracker.Domain.Entities;

namespace TVShowTracker.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Show> Shows { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}