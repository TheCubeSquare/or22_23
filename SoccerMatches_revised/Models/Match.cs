using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace SoccerMatches_revised.Models
{
    public class Match
    {
        public int matchid { get; set; }
        public string first_team { get; set; }
        public int first_team_goals { get; set; }
        public string second_team { get; set; }
        public int second_team_goals { get; set; }
        public DateTime date { get; set; }
        public string stadium { get; set; }
        //public ICollection<Player> FirstTeamPlayers { get; set; }
        //public ICollection<Player> SecondTeamPlayers { get; set; }
        //public ICollection<Substitution> Substitutions { get; set; }
    }
}
