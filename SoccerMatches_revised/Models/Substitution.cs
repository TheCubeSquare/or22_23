namespace SoccerMatches_revised.Models
{
    public class Substitution
    {
        public int Id { get; set; }
        public string OutgoingPlayerName { get; set; }
        public string OutgoingPlayerSurname { get; set; }
        public string IncomingPlayerName { get; set; }
        public string IncomingPlayerSurname { get; set; }
    }
}
