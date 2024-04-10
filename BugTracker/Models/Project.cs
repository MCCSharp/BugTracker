using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class Project
    {
        [Key]
        public int Id { get; init; }
        public string Logo { get; set; } = string.Empty;
        public string Title { get; init; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; init; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; } = null;
        public int Budjet { get; init; }
      
        public   ICollection<Ticket>? Tickets { get; set; }
        public  ICollection<Module>? Modules { get; set; }
        public  ICollection<Mitarbeiter> Mitarbeiters { get; set; }


    }
}
