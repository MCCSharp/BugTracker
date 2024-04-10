using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Models;

namespace BugTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly BugContext _context;

        public ProjectController(BugContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
              return _context.Projekts != null ? 
                          View(await _context.Projekts.ToListAsync()) :
                          Problem("Entity set 'BugContext.Projekts'  is null.");
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
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

    }
}
