namespace BugTracker.Models.ViewModels
{
    public class ProgrammerViewModels
    {
        public string Profile { get; set; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }

        public string Aufgabe { get; set; }
        public List<Ticket>? Tickets { get; set; }
        public List<Log>? Logs { get; set; }
        public List<Project> Projects { get; set; }

        public ProgrammerViewModels(Mitarbeiter mitarbeiter)
        {
            Profile = mitarbeiter.Profile;
            Firstname = mitarbeiter.Firstname;
            Lastname = mitarbeiter.Lastname;
            Aufgabe = mitarbeiter.Aufgabe;
            Tickets = mitarbeiter.Tickets?.ToList();
            Logs = mitarbeiter.Logs?.ToList();
            Projects = mitarbeiter.Projects.ToList();
        }
    }
}
