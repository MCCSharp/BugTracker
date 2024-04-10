using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Mitarbeiter
    {
        

        [Key]
        public int Id { get; init; }
        public string Profile { get; set; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }

        public string Aufgabe { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Log>? Logs { get; set; }
        public ICollection<Project>  Projects { get; set; }


        //public Mitarbeiter(int id, string profile, string firstname, string lastname, string aufgabe, List<Ticket>? tickets, List<Log>? logs, List<Project> projects)
        //{
        //    Id = id;
        //    Profile = profile;
        //    Firstname = firstname;
        //    Lastname = lastname;
        //    Aufgabe = aufgabe;
        //    Tickets = tickets;
        //    Logs = logs;
        //    Projects = projects;
        //}

    }
}
