namespace Lab1.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }

        //Sql database foregin keys
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}
