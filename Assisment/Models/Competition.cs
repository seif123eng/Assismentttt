using System.ComponentModel.DataAnnotations;

namespace Assisment.Models
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public List<Team>? teams { get; set; } = new List<Team>();

    }
}
