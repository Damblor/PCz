namespace Lab1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Index { get; set; }
        public DateTime BirthDate { get; set; }
        public string Faculty { get; set; } = string.Empty;
    }
}
