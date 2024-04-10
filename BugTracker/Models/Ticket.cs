using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Ticket
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public Project Project { get; init; }
        public  Mitarbeiter Mitarbeiter { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm}")]
        public DateTime Created { get; init; }= DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; } = null;
        public string? Description { get; set; }
        [NotMapped]
        public bool IsActive { get; set; }
        public virtual ICollection<Log>? Logs { get; set; }

    }
}
