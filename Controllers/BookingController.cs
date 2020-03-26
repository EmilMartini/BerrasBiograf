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
        private readonly CinemaContext _context;
        private readonly UserManager<User> _userManager;

        public BookingController(CinemaContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var bookings = from booking in await _context.Bookings.ToListAsync()
                           where booking.User == currentUser
                           join viewing in await _context.Viewings.ToListAsync() on booking.Viewing.Id equals viewing.Id
                           join movie in await _context.Movies.ToListAsync() on viewing.MovieToShow.Id equals movie.Id
                           join locale in await _context.Locales.ToListAsync() on viewing.LocaleToShow.Id equals locale.Id
                           join user in await _context.Users.ToListAsync() on booking.User equals user
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
            var viewing = await _context.Viewings.FindAsync(id);
            if (viewing == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return View(viewing);
        }


        public async Task<IActionResult> AddBooking(Guid? id, AddBookingModel bookingModel)
        {
            if(id == null)
            {
                return NotFound();
            }

            var viewing = await _context.Viewings.FindAsync(id);
            var user = await _userManager.GetUserAsync(User);

            var booking = new Booking
            {
                Id = new Guid(),
                Viewing = viewing,
                User = user,
                NumberOfBookedSeats = 10,
                TimeOfBooking = DateTime.Now
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}