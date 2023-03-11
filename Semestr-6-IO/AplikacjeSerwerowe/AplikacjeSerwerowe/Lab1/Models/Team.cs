namespace Lab1.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime FoundingDate { get; set; }

        //Sql database foregin keys
        public int LeagueId { get; set; }
        public League League { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Match> HomeMatches { get; set; }
        public ICollection<Match> AwayMatches { get; set; }
    }
}
