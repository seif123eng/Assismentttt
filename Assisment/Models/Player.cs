using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assisment.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Full_name { get; set; }
        public string position { get; set; }
        public int age { get; set; }
        public Team? team { get; set; }
        [ForeignKey(nameof(team))]
        public int teamID { get; set; }

    }
}
