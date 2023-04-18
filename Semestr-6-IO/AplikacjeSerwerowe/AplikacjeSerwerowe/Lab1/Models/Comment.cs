namespace Lab1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        //Sql database foregin keys
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
