namespace BugTracker.Models
{
    public class BugRepository : IBugRepository
    {
        private readonly BugContext _context;

        public BugRepository(BugContext ctx)
        {
            _context = ctx;
        }
        public IQueryable<Ticket> Tickets => _context.Tickets;

        public IQueryable<Mitarbeiter> Mitarbeiters => _context.Mitarbeiters;

        public IQueryable<Project> Projekts => _context.Projekts;


        public IQueryable<Module> Modules => _context.Modules;

        public IQueryable<Log> Logs => _context.Logs;
    }
}
