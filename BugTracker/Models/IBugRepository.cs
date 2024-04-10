namespace BugTracker.Models
{
    public interface IBugRepository
    {
        IQueryable<Ticket> Tickets { get; }
        IQueryable<Mitarbeiter> Mitarbeiters { get;}
        IQueryable<Project> Projekts {get;}
        IQueryable<Module> Modules { get;}
        IQueryable<Log> Logs {  get;}
    }
}
