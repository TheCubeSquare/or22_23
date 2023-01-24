using System;
using SoccerMatches_revised.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SoccerMatches_revised.ViewModels
{
    public class SoccerMatchViewModel
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
