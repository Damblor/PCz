namespace AS_k1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public int RokWydania { get; set; }

        //Sql
        public int? LibraryId { get; set; }
        public virtual Library Library { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

    }
}
