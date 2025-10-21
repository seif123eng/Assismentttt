namespace Assisment.DTOs
{
    public class competetionDTO
    {
        public string name {  get; set; }
        public string location { get; set; }
        public object total_participatingTeams {  get; set; }
        public List<GetNameDTO> team {  get; set; }
    }
}
