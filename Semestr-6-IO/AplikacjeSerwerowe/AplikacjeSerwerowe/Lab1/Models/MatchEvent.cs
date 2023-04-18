namespace Lab1.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }

        //Sql database foregin keys
        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
        public int? MatchPlayerId { get; set; }
        public virtual MatchPlayer MatchPlayer { get; set; }
    }
}
