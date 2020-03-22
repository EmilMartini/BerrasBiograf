using System;
using System.Collections.Generic;
using System.Linq;

namespace BerrasBiograf
{
    public static class DbInitializer
    {
        
        public static void Initialize(CinemaContext context, bool seed)
        {
            if (seed) 
            { 
                var cinema = new Cinema
                {
                    Id = new Guid(),
                    Locales = new List<Locale>
                    {
                        new Locale
                        {
                            Id = new Guid(),
                            LocaleName = "Stora salongen",
                            TotalSeats = 100,                          
                        },
                        new Locale
                        {
                            Id = new Guid(),
                            LocaleName = "Lilla salongen",
                            TotalSeats = 50
                        }
                    }
                };
                context.Cinemas.Add(cinema);

                var movie = new Movie
                {
                    Id = new Guid(),
                    Genre = Genre.Comedy,
                    Length = 3.5,
                    Title = "Emils programmerings-session"
                };
                context.Movies.Add(movie);

                var movie2 = new Movie
                {
                    Id = new Guid(),
                    Genre = Genre.Thriller,
                    Length = 1.5,
                    Title = "Emils ickeexisterande Nap"
                };
                context.Movies.Add(movie2);

                var movie3 = new Movie
                {
                    Id = new Guid(),
                    Genre = Genre.Action,
                    Length = 3.5,
                    Title = "Daniels klättersession"
                };
                context.Movies.Add(movie3);
                context.SaveChanges();

                var emilsNapViewing = new Viewing
                {
                    Id = new Guid(),
                    LocaleToShow = context.Locales.Where(o => o.TotalSeats == 50).FirstOrDefault(),
                    AvailableSeats = 50,
                    MovieToShow = context.Movies.Where(o => o.Title == "Emils ickeexisterande Nap").FirstOrDefault(),
                    TimeOfScreening = DateTime.Now.AddDays(3)
                };
                context.Viewings.Add(emilsNapViewing);

                var danielsKlättringViewing = new Viewing
                {
                    Id = new Guid(),
                    LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                    AvailableSeats = 100,
                    MovieToShow = context.Movies.Where(o => o.Title == "Daniels klättersession").FirstOrDefault(),
                    TimeOfScreening = DateTime.Now.AddDays(5)
                };
                context.Viewings.Add(danielsKlättringViewing);

                var emilsProgramming = new Viewing
                {
                    Id = new Guid(),
                    LocaleToShow = context.Locales.Where(o => o.TotalSeats == 50).FirstOrDefault(),
                    AvailableSeats = 50,
                    MovieToShow = context.Movies.Where(o => o.Title == "Daniels klättersession").FirstOrDefault(),
                    TimeOfScreening = DateTime.Now.AddDays(4)
                };
                context.Viewings.Add(emilsProgramming);

                context.SaveChanges(); 
            }
        }
    }
}