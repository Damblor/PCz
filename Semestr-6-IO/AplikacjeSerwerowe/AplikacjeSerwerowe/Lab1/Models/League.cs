namespace Lab1.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int Level { get; set; }

        //Sql database foregin keys
        public virtual ICollection<Team> Teams { get; set; }
    }
}
