using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BerrasBiograf
{
    public class CinemaContext : IdentityDbContext<User>
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<Viewing> Viewings { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
