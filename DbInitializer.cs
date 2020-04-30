using System;
using System.Collections.Generic;
using System.Linq;

namespace BerrasBiograf
{
    public static class DbInitializer
    {
        public static void Seed(CinemaContext context)
        {
            context.Cinemas.Add(new Cinema 
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
                });
            context.Movies.Add(new Movie
            {
                Id = new Guid(),
                Genre = Genre.Action,
                Length = 3,
                Title = "Lord of the rings - Return of the king",
                AgeRestriction = 15,
                ImageLink = "/images/lotrReturnOfTheKing.jpg"
            });
            context.Movies.Add(new Movie
            {
                Id = new Guid(),
                Genre = Genre.Comedy,
                Length = 2,
                Title = "Jackass 3",
                AgeRestriction = 18,
                ImageLink = "/images/jackass3.jpg"
            });
            context.Movies.Add(new Movie
            {
                Id = new Guid(),
                Genre = Genre.Thriller,
                Length = 3.5,
                Title = "The Irishmen",
                AgeRestriction = 15,
                ImageLink = "/images/irishmen.jpg"
            });
            context.Movies.Add(new Movie
            {
                Id = new Guid(),
                Genre = Genre.Action,
                Length = 3,
                AgeRestriction = 15,
                Title = "Batman - The Dark Knight",
                ImageLink = "/images/batmanDarkKnight.jpg"
            });
            context.SaveChanges();


            var earlyScreening = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 30, 00);
            var lateScreening = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 21, 30, 00);
            for (int i = 0; i < 7; i++)
            {
                if (earlyScreening.AddDays(i) > DateTime.Now)
                {
                    context.Viewings.Add(new Viewing
                    {
                        Id = new Guid(),
                        LocaleToShow = context.Locales.Where(o => o.TotalSeats == 50).FirstOrDefault(),
                        AvailableSeats = 50,
                        MovieToShow = context.Movies.Where(o => o.Title == "Jackass 3").FirstOrDefault(),
                        TimeOfScreening = earlyScreening.AddDays(i)
                    });
                    context.Viewings.Add(new Viewing
                    {
                        Id = new Guid(),
                        LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                        AvailableSeats = 99,
                        MovieToShow = context.Movies.Where(o => o.Title == "The Irishmen").FirstOrDefault(),
                        TimeOfScreening = earlyScreening.AddDays(i)
                    });
                }
                if (lateScreening.AddDays(i) > DateTime.Now)
                {
                    context.Viewings.Add(new Viewing
                    {
                        Id = new Guid(),
                        LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                        AvailableSeats = 94,
                        MovieToShow = context.Movies.Where(o => o.Title == "Lord of the rings - Return of the king").FirstOrDefault(),
                        TimeOfScreening = lateScreening.AddDays(i)
                    });
                    context.Viewings.Add(new Viewing
                    {
                        Id = new Guid(),
                        LocaleToShow = context.Locales.Where(o => o.TotalSeats == 50).FirstOrDefault(),
                        AvailableSeats = 40,
                        MovieToShow = context.Movies.Where(o => o.Title == "Batman - The Dark Knight").FirstOrDefault(),
                        TimeOfScreening = lateScreening.AddDays(i)
                    });
                }
            }
            context.SaveChanges(); 
        }
    }
}