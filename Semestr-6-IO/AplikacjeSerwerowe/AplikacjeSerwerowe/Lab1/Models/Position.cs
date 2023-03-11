namespace Lab1.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Sql database foregin keys
        public ICollection<Player> Players { get; set; }
        public ICollection<MatchPlayer> MatchPlayers { get; set; }
    }
}
