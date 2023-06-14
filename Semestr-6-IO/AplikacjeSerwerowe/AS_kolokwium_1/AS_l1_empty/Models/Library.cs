namespace AS_k1.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        //Sql
        public virtual ICollection<Book> Books { get; set; }
    }
}
