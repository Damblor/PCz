namespace Lab1.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }

        //Sql database foregin keys
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }  
        public ICollection<Tag> Tags { get; set; }
        public int? MatchId { get; set; }
        public virtual Match Match { get; set; }
    }
}
