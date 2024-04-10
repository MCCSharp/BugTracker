using BugTracker.Models;
using BugTracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BugTracker.Controllers
{
    public class ProgrammerController : Controller
    {
        private readonly BugContext _context;

        public ProgrammerController(BugContext context)
        {
            _context = context;
        }

        // GET: Mitarbeiter
        public async Task<IActionResult> Index()
        {
           
            return _context.Mitarbeiters.Where(m => m.Aufgabe == "Programmer").OrderBy(m=>m.Lastname) != null ?
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
                .FirstOrDefaultAsync((m) => m.Id == id && m.Aufgabe == "Programmer");
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

        //Log

        //public async Task<IActionResult> LogIndex()
        //{
        //    return _context.Logs != null ?
        //                View(await _context.Logs.ToListAsync()) :
        //                Problem("Entity set 'BugContext.Logs'  is null.");
        //}
        public IActionResult LogCreate()
        {
            return View();
        }

        // POST: Log/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatedDate,Description")] Log log)
        {
            if (ModelState.IsValid)
            {
                _context.Add(log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(log);
        }

        //Ticket
        public async Task<IActionResult> TicketIndex(int id)
        {
             var logMa = _context.Logs.Where(l => l.Mitarbeiter.Id == id).FirstOrDefault();
            return _context.Tickets.Where(t => t.Logs == logMa) != null ?
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
