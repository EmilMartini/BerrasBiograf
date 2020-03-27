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

        //BOKA BIO VY-CALL

        // GET: Viewings/Create

        // POST: Viewings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,AvailableSeats,TimeOfScreening")] Viewing viewing)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        viewing.Id = Guid.NewGuid();
        //        _context.Add(viewing);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(viewing);
        //}
        //
        //// GET: Viewings/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //
        //    var viewing = await _context.Viewings.FindAsync(id);
        //    if (viewing == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(viewing);
        //}
        //
        //// POST: Viewings/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        





        
        //
        //// GET: Viewings/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //
        //    var viewing = await _context.Viewings
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (viewing == null)
        //    {
        //        return NotFound();
        //    }
        //
        //    return View(viewing);
        //}
        //
        //// POST: Viewings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var viewing = await _context.Viewings.FindAsync(id);
        //    _context.Viewings.Remove(viewing);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ViewingExists(Guid id)
        {
            return _context.Viewings.Any(e => e.Id == id);
        }
    }
}
