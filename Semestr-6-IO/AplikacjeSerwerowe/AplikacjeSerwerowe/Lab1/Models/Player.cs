namespace Lab1.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        //Sql database foregin keys
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Position> Positions { get; set; }
        public ICollection<MatchPlayer> MatchPlayers { get; set; }
    }
}
