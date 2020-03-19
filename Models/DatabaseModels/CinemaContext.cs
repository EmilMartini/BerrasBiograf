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
        public DbSet<Schedule> Schedules { get; set; }

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }
    }
}
