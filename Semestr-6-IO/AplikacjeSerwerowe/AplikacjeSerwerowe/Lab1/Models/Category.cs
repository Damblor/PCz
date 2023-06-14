﻿namespace Lab1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Article> Articles { get; set; }
    }
}
