namespace Lab1.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }

        //Sql database foregin keys
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
