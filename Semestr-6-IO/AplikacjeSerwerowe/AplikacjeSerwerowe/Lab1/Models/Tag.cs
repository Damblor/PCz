namespace Lab1.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //Sql database foregin keys
        public ICollection<Article> Articles { get; set; }
    }
}
