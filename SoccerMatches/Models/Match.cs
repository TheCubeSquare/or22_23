using System.ComponentModel.DataAnnotations;

namespace SoccerMatches.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string? FirstTeam { get; set; }
        public int FirstTeamGoals { get; set; }
        public string? SecondTeam { get; set;}
        public int SecondTeamGoals { get; set; }
        public string? Stadium { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
