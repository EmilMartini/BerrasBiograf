using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}