using System.ComponentModel.DataAnnotations;

namespace Assisment.DTOs
{
    public class coachDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public object team { get; set; }
    }

    public class specificcoachDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object team { get; set; }
        public int total_players { get; set; }
    } 
}
