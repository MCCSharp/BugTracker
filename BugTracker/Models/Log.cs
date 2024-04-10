using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public Mitarbeiter Mitarbeiter { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm}")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
    }
}