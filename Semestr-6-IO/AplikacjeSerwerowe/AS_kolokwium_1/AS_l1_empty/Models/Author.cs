namespace AS_k1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        //Sql
        public virtual ICollection<Book> Books { get; set; }
    }
}
