using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class BookingController : Controller
    {
        private readonly CinemaContext context;
        private readonly UserManager<User> userManager;

        public BookingController(CinemaContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(User);

            var bookings = from booking in await context.Bookings.ToListAsync()
                           where booking.User == currentUser
                           join viewing in await context.Viewings.ToListAsync() on booking.Viewing.Id equals viewing.Id
                           join movie in await context.Movies.ToListAsync() on viewing.MovieToShow.Id equals movie.Id
                           join locale in await context.Locales.ToListAsync() on viewing.LocaleToShow.Id equals locale.Id
                           join user in await context.Users.ToListAsync() on booking.User equals user
                           orderby booking.TimeOfBooking ascending
                           select booking;

            return View(bookings);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BookViewing(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewing = await context.Viewings.FindAsync(id);
            if (viewing == null)
            {
                return NotFound();
            }
            await context.SaveChangesAsync();
            return View(viewing);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBooking(Guid? id, AddBookingModel model)
        {
            var user = userManager.GetUserAsync(User).Result;
            var viewing = context.Viewings.Single(o => o.Id == id);
            viewing.AvailableSeats -= model.NumberOfBookedSeats;
            context.Viewings.Update(viewing);
            await context.SaveChangesAsync();

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                NumberOfBookedSeats = model.NumberOfBookedSeats,
                TimeOfBooking = DateTime.Now,
                User = user,
                Viewing = context.Viewings.Single(o => o.Id == id)
            };
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();

            return View(booking);
        }
    }
}