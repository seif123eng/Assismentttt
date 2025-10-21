using Assisment.Models;

namespace Assisment.DTOs
{
    public class TeamDTO
    {
        public string Name { get; set; }
        public string city { get; set; }
        public int coachID { get; set; }
    }
    public class Non_RegisterDTO
    {
        public string Name { get; set; }
        public int total_players { get; set; } 
    }
    public class GetYoungestInTeamDTO 
    {
        public string Name { get; set; }
        public youngestplayerDTO youngest_player { get; set; }
    }
    public class GetNameDTO
    {
        public string Name { get; set; }
        public int total_players { get; set; }
    }
    
}
