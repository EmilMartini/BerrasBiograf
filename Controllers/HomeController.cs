using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BerrasBiograf
{
    public class HomeController : Controller
    {
        private readonly CinemaContext context;
        private readonly UserManager<User> userManager;

        public HomeController(CinemaContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var viewings = from viewing in await context.Viewings.ToListAsync()
                                 join movie in await context.Movies.ToListAsync() on viewing.MovieToShow.Id equals movie.Id
                                 join locale in await context.Locales.ToListAsync() on viewing.LocaleToShow.Id equals locale.Id
                                 orderby viewing.TimeOfScreening ascending
                                 select viewing;

            return View(viewings);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewing = await context.Viewings.SingleAsync(o => o.Id == id);
            if (viewing == null)
            {
                return NotFound();
            }
            var bookingModel = new AddBookingModel
            {
                User = await userManager.GetUserAsync(User),
                Viewing = viewing
            };

            return View(bookingModel);
        }

        public IActionResult Seed()
        {
            DbInitializer.Initialize(context);
            return RedirectToAction("Index");
        }
    }
}
