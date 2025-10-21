using System.ComponentModel.DataAnnotations;

namespace Assisment.Models
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int experience_years { get; set; }
        public Team? team { get; set; }
    }
}
