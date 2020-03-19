using System;
using System.Collections.Generic;
using System.Linq;

namespace BerrasBiograf
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaContext context, int numberOfMovies)
        {
            if(context.Cinemas.ToList().Count < 1)
            {
                var rnd = new Random();
                List<Locale> locales;
                List<Viewing> viewings;
                List<Movie> movies = new List<Movie>();

                for (int i = 0; i < numberOfMovies; i++)
                {
                    Movie newMovie = new Movie
                    {
                        Id = new Guid(),
                        Genre = (Genre)rnd.Next(0, 5),
                        Length = 2.0f,
                        Title = "Title " + i
                    };
                    movies.Add(newMovie);
                }

                locales = new List<Locale> {
                new Locale
                {
                    Id = new Guid(),
                    LocaleName = "Lilla salongen",
                    TotalSeats = 50
                },
                new Locale
                {
                    Id = new Guid(),
                    LocaleName = "Stora salongen",
                    TotalSeats = 100
                }
            };

                viewings = new List<Viewing> {
                new Viewing
                {
                    Id = new Guid(),
                    AvailableSeats = 15,
                    LocaleToShow = locales[0],
                    MovieToShow = movies[rnd.Next(0, movies.Count)],
                    TimeOfScreening = DateTime.Now
                },
                new Viewing
                {
                    Id = new Guid(),
                    AvailableSeats = 40,
                    LocaleToShow = locales[1],
                    MovieToShow = movies[rnd.Next(0,movies.Count)],
                    TimeOfScreening = DateTime.Now
                }
            };

                for (int i = 0; i < locales.Count; i++)
                {
                    locales[i].Viewings = viewings.Where(o => o.LocaleToShow.Id == locales[i].Id).ToList();
                }

                Cinema cinema = new Cinema
                {
                    Id = new Guid(),
                    Locales = locales,
                    Movies = movies
                };
                context.Cinemas.Add(cinema);
                context.SaveChanges();
            }
        }
    }
}