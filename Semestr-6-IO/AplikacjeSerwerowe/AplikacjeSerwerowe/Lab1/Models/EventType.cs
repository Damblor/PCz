namespace Lab1.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Sql database foregin keys
        public virtual ICollection<MatchEvent> MatchEvents { get; set; }
    }
}
