using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Controllers
{
    public class AdminController : Controller
    {
        private readonly BugContext _context;

        public AdminController(BugContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Mitarbeiter

        // GET: Mitarbeiter
        public async Task<IActionResult> MitarbeiterIndex()
        {
            return _context.Mitarbeiters != null ?
                        View(await _context.Mitarbeiters.ToListAsync()) :
                        Problem("Entity set 'BugContext.Mitarbeiters'  is null.");
        }

        // GET: Mitarbeiter/Details/5
        public async Task<IActionResult> MitarbeiterDetails(int? id)
        {
            if (id == null || _context.Mitarbeiters == null)
            {
                return NotFound();
            }

            var mitarbeiter = await _context.Mitarbeiters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            return View(mitarbeiter);
        }
        // GET: Mitarbeiter/Create
        public IActionResult MitarbeiterCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MitarbeiterCreate([Bind("Id,Profile,Firstname,Lastname,Aufgabe")] Mitarbeiter mitarbeiter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mitarbeiter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mitarbeiter);
        }

        // GET: Mitarbeiter/Edit/5
        public async Task<IActionResult> MitarbeiterEdit(int? id)
        {
            if (id == null || _context.Mitarbeiters == null)
            {
                return NotFound();
            }

            var mitarbeiter = await _context.Mitarbeiters.FindAsync(id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }
            return View(mitarbeiter);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MitarbeiterEdit(int id, [Bind("Id,Profile,Firstname,Lastname,Aufgabe")] Mitarbeiter mitarbeiter)
        {
            if (id != mitarbeiter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mitarbeiter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MitarbeiterExists(mitarbeiter.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mitarbeiter);
        }

        // GET: Mitarbeiter/Delete/5
        public async Task<IActionResult> MitarbeiterDelete(int? id)
        {
            if (id == null || _context.Mitarbeiters == null)
            {
                return NotFound();
            }

            var mitarbeiter = await _context.Mitarbeiters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mitarbeiter == null)
            {
                return NotFound();
            }

            return View(mitarbeiter);
        }

        // POST: Mitarbeiter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MitarbeiterDeleteConfirmed(int id)
        {
            if (_context.Mitarbeiters == null)
            {
                return Problem("Entity set 'BugContext.Mitarbeiters'  is null.");
            }
            var mitarbeiter = await _context.Mitarbeiters.FindAsync(id);
            if (mitarbeiter != null)
            {
                _context.Mitarbeiters.Remove(mitarbeiter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MitarbeiterExists(int id)
        {
            return (_context.Mitarbeiters?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // Project

        // GET: Project
        public async Task<IActionResult> ProjectIndex()
        {
            return _context.Projekts != null ?
                        View(await _context.Projekts.ToListAsync()) :
                        Problem("Entity set 'BugContext.Projekts'  is null.");
        }

        // GET: Project/Details/5
        public async Task<IActionResult> ProjectDetails(int? id)
        {
            if (id == null || _context.Projekts == null)
            {
                return NotFound();
            }

            var project = await _context.Projekts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Project/Create
        public IActionResult ProjectCreate()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectCreate([Bind("Id,Logo,Title,StartDate,EndDate,Budjet")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> ProjectEdit(int? id)
        {
            if (id == null || _context.Projekts == null)
            {
                return NotFound();
            }

            var project = await _context.Projekts.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectEdit(int id, [Bind("Id,Logo,Title,StartDate,EndDate,Budjet")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> ProjectDelete(int? id)
        {
            if (id == null || _context.Projekts == null)
            {
                return NotFound();
            }

            var project = await _context.Projekts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProjectDeleteConfirmed(int id)
        {
            if (_context.Projekts == null)
            {
                return Problem("Entity set 'BugContext.Projekts'  is null.");
            }
            var project = await _context.Projekts.FindAsync(id);
            if (project != null)
            {
                _context.Projekts.Remove(project);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return (_context.Projekts?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //Ticket

        public async Task<IActionResult> TicketIndex()
        {
            return _context.Tickets != null ?
                        View(await _context.Tickets.ToListAsync()) :
                        Problem("Entity set 'BugContext.Tickets'  is null.");
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> TicketEdit(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TicketEdit(int id, [Bind("Id,Title,Created,EndDate,Description")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> TicketDelete(int? id)
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

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TicketDeleteConfirmed(int id)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity set 'BugContext.Tickets'  is null.");
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        //Log
        //Add id Param + show log from MAid
        public async Task<IActionResult> LogIndex()
        {
            return _context.Logs != null ?
                        View(await _context.Logs.ToListAsync()) :
                        Problem("Entity set 'BugContext.Logs'  is null.");
        }

        // GET: Log/Delete/5
        public async Task<IActionResult> LogDelete(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogDeleteConfirmed(int id)
        {
            if (_context.Logs == null)
            {
                return Problem("Entity set 'BugContext.Logs'  is null.");
            }
            var log = await _context.Logs.FindAsync(id);
            if (log != null)
            {
                _context.Logs.Remove(log);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogExists(int id)
        {
            return (_context.Logs?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //Module

        // GET: Module
        //Add id Param + show Module from projekt id
        public async Task<IActionResult> ModuleIndex()
        {
            return _context.Modules != null ?
                        View(await _context.Modules.ToListAsync()) :
                        Problem("Entity set 'BugContext.Modules'  is null.");
        }

        // GET: Module/Details/5
        public async Task<IActionResult> ModuleDetails(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var @module = await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // GET: Module/Create
        public IActionResult ModuleCreate()
        {
            return View();
        }

        // POST: Module/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Module @module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }

        // GET: Module/Edit/5
        public async Task<IActionResult> ModuleEdit(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var @module = await _context.Modules.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }
            return View(@module);
        }

        // POST: Module/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Module @module)
        {
            if (id != @module.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(@module.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@module);
        }

        // GET: Module/Delete/5
        public async Task<IActionResult> ModuleDelete(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var @module = await _context.Modules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // POST: Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modules == null)
            {
                return Problem("Entity set 'BugContext.Modules'  is null.");
            }
            var @module = await _context.Modules.FindAsync(id);
            if (@module != null)
            {
                _context.Modules.Remove(@module);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleExists(int id)
        {
            return (_context.Modules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
