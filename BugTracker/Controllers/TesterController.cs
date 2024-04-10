using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers
{
    public class TesterController : Controller
    {
        private readonly BugContext _context;

        public TesterController(BugContext context)
        {
            _context = context;
        }

        // GET: Tester
        public async Task<IActionResult> Index()
        {
            return _context.Mitarbeiters.Where(m => m.Aufgabe == "Tester").OrderBy(m => m.Lastname) != null ?
                   View(await _context.Mitarbeiters.ToListAsync()) :
                   Problem("Entity set 'BugContext.Mitarbeiters'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mitarbeiters == null)
            {
                return NotFound();
            }

            var mitarbeiter = await _context.Mitarbeiters
                .FirstOrDefaultAsync((m) => m.Id == id && m.Aufgabe == "Tester");
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            return View(mitarbeiter);
        }
        private bool MitarbeiterExists(int id)
        {
            return (_context.Mitarbeiters?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //Ticket

        // GET: Ticket/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Created,EndDate,Description")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        public async Task<IActionResult> TicketIndex(int id)
        {
            return _context.Tickets.Where(t=> t.Mitarbeiter.Id == id) != null ?
                        View(await _context.Tickets.ToListAsync()) :
                        Problem("Entity set 'BugContext.Tickets'  is null.");
        }


        // GET: Tickets/Details/5
        public async Task<IActionResult> TicketsDetails(int? id)
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
