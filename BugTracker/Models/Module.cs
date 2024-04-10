using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public Project Project { get; set; }
    }
}