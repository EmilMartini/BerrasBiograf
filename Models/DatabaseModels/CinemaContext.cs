using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class CinemaContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<Viewing> Viewings { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaLocales> CinemaLocales {get; set;}
        public DbSet<CinemaMovies> CinemaMovies { get; set; }
        public DbSet<LocaleViewings> LocaleViewings { get;  set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }
    }
}
