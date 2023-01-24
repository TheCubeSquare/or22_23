using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace SoccerMatches_revised.Models
{
    public class SoccerMatch
    {
        public int Id { get; set; }
        public string FirstTeam { get; set; }
        public int FirstTeamGoals { get; set; }
        public string SecondTeam { get; set; }
        public int SecondTeamGoals { get; set; }
        public TimeSpan Date { get; set; }
        public string Stadium { get; set; }
        public ICollection<Player> FirstTeamPlayers { get; set; }
        public ICollection<Player> SecondTeamPlayers { get; set; }
        public ICollection<Substitution> Substitutions { get; set; }
    }
}
