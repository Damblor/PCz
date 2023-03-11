namespace Lab1.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }

        //Sql database foregin keys
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int? MatchPlayerId { get; set; }
        public virtual MatchPlayer MatchPlayer { get; set; }
    }
}
