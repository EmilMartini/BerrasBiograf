using System;
using System.Collections.Generic;
using System.Linq;

namespace BerrasBiograf
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaContext context)
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

            context.Viewings.Add(new Viewing
            {
                Id = new Guid(),
                LocaleToShow = context.Locales.Where(o => o.TotalSeats == 50).FirstOrDefault(),
                AvailableSeats = 50,
                MovieToShow = context.Movies.Where(o => o.Title == "Jackass 3").FirstOrDefault(),
                TimeOfScreening = DateTime.Now.AddDays(0)
            });
            context.Viewings.Add(new Viewing
            {
                Id = new Guid(),
                LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                AvailableSeats = 100,
                MovieToShow = context.Movies.Where(o => o.Title == "The Irishmen").FirstOrDefault(),
                TimeOfScreening = DateTime.Now.AddDays(0)
            });
            context.Viewings.Add(new Viewing
            {
                Id = new Guid(),
                LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                AvailableSeats = 100,
                MovieToShow = context.Movies.Where(o => o.Title == "Lord of the rings - Return of the king").FirstOrDefault(),
                TimeOfScreening = DateTime.Now.AddDays(3)
            });
            context.Viewings.Add(new Viewing
            {
                Id = new Guid(),
                LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                AvailableSeats = 100,
                MovieToShow = context.Movies.Where(o => o.Title == "Batman - The Dark Knight").FirstOrDefault(),
                TimeOfScreening = DateTime.Now.AddDays(1)
            });
            context.Viewings.Add(new Viewing
            {
                Id = new Guid(),
                LocaleToShow = context.Locales.Where(o => o.TotalSeats == 50).FirstOrDefault(),
                AvailableSeats = 50,
                MovieToShow = context.Movies.Where(o => o.Title == "Jackass 3").FirstOrDefault(),
                TimeOfScreening = DateTime.Now.AddDays(2)
            });
            context.Viewings.Add(new Viewing
            {
                Id = new Guid(),
                LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                AvailableSeats = 100,
                MovieToShow = context.Movies.Where(o => o.Title == "The Irishmen").FirstOrDefault(),
                TimeOfScreening = DateTime.Now.AddDays(3)
            });
            context.Viewings.Add(new Viewing
            {
                Id = new Guid(),
                LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                AvailableSeats = 100,
                MovieToShow = context.Movies.Where(o => o.Title == "Lord of the rings - Return of the king").FirstOrDefault(),
                TimeOfScreening = DateTime.Now.AddDays(1)
            });
            context.Viewings.Add(new Viewing
            {
                Id = new Guid(),
                LocaleToShow = context.Locales.Where(o => o.TotalSeats == 100).FirstOrDefault(),
                AvailableSeats = 100,
                MovieToShow = context.Movies.Where(o => o.Title == "Batman - The Dark Knight").FirstOrDefault(),
                TimeOfScreening = DateTime.Now.AddDays(2)
            });
            context.SaveChanges(); 
        }
    }
}