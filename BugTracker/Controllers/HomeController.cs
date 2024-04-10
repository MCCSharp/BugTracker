using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
      

        //private readonly IBugRepository repository;
        //public HomeController(IBugRepository repo)
        //{
        //    repository = repo;   
        //}
        private readonly BugContext _context;

        public HomeController(BugContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Tickets != null ?
                        View(await _context.Tickets.ToListAsync()) :
                        Problem("Entity set 'BugContext.Tickets'  is null.");
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
    }
}