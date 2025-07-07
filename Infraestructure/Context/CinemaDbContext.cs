using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Infraestructure.Context
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
        }
        // Define base entities
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationships

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Theater)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TheaterId);

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Reviews)
                .WithOne(r => r.Film)
                .HasForeignKey(r => r.FilmId);

            modelBuilder.Entity<Theater>()
                .HasMany(t => t.Films)
                .WithMany(f => f.Theaters);
        }
    }
}
