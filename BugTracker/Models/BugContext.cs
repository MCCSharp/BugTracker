using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models
{
    public class BugContext : DbContext
    {
        public BugContext(DbContextOptions<BugContext> options) : base(options) { }


        public DbSet<Mitarbeiter> Mitarbeiters => Set<Mitarbeiter>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Project> Projekts => Set<Project>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<Log> Logs => Set<Log>();
    }
}
