using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BerrasBiograf
{
    public class ViewingsController : Controller
    {
        private readonly CinemaContext _context;

        public ViewingsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Viewings

        public async Task<IActionResult> Index()
        {
            var viewings = from viewing in await _context.Viewings.ToListAsync()
                                 join movie in await _context.Movies.ToListAsync() on viewing.MovieToShow.Id equals movie.Id
                                 join locale in await _context.Locales.ToListAsync() on viewing.LocaleToShow.Id equals locale.Id
                                 orderby viewing.TimeOfScreening ascending
                                 select viewing;

            return View(viewings);
        }

        // GET: Viewings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewing = await _context.Viewings.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (viewing == null)
            {
                return NotFound();
            }

            return View(viewing);
        }

        public IActionResult Seed()
        {
            DbInitializer.Initialize(_context);
            return RedirectToAction("Index");
        }

        

        

        private bool ViewingExists(Guid id)
        {
            return _context.Viewings.Any(e => e.Id == id);
        }
    }
}
