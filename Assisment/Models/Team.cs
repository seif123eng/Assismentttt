using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assisment.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //unique
        public string Name { get; set; }
        public string city { get; set; }
        public Coach? coach { get; set; }
        [ForeignKey(nameof(coach))]
        public int coachID { get; set; }
        public List<Player>? players { get; set; }= new List<Player>();
        public List<Competition>? competitions { get; set; } = new List<Competition>();

    }
}
