using System;
using System.Collections.Generic;
using System.Linq;

namespace BerrasBiograf
{
    public static class DbInitializer
    {
        
        public static void Initialize(CinemaContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var cinema = new Cinema
                {
                };

                var locale = new Locale
                {
                    LocaleName = "Stora salongen",
                    TotalSeats = 500
                };

                context.Cinemas.Add(cinema);
                context.Locales.Add(locale);
                context.SaveChanges(); 
            }
        }
    }
}