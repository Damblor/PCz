using System;
using System.Linq;

namespace Zad3
{
    public class Ksiazka
    {
        public string Tytul { get; set; }
        public int RokWydania { get; set; }
        public int Autor { get; set; }
        public double Cena { get; set; }
    }

    public class Autor
    {
        public int id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            var ksiazki = new[] {

                new Ksiazka {Tytul = "Pan Tadeusz", RokWydania = 1998, Autor = 1, Cena = 30},
                new Ksiazka {Tytul = "Potop", RokWydania = 1991, Autor = 2, Cena = 40},
                new Ksiazka {Tytul = "W pustyni i w puszczy", RokWydania = 1990, Autor = 2, Cena = 30},
                new Ksiazka {Tytul = "Lalka", RokWydania = 1990, Autor = 3, Cena = 50},
                new Ksiazka {Tytul = "Programowanie funkcyjne w języku C#", RokWydania = 2019, Autor = 4, Cena = 71.20},
                new Ksiazka {Tytul = "Programowanie funkcyjne z JavaScriptem", RokWydania = 2017,  Autor = 5, Cena = 29.40},
            };
            
            var autorzy = new[] {
                new Autor { id = 1, Imie = "Adam", Nazwisko = "Mickiewicz" },
                new Autor { id = 2, Imie = "Henryk", Nazwisko = "Sienkiewicz" },
                new Autor { id = 3, Imie = "Bolesław", Nazwisko = "Prus" },
                new Autor { id = 4, Imie = "Enrico", Nazwisko = "Buonanno" },
                new Autor { id = 5, Imie = "Luis", Nazwisko = "Atencio" },
                new Autor { id = 6, Imie = "Robert C.", Nazwisko = "Martin" },
            };

            var lista =
                (from a in autorzy
                 join k in ksiazki on a.id equals k.Autor
                 into grupy
                 from g in grupy.DefaultIfEmpty()
                 select new { Autor = $"{a.Imie} {a.Nazwisko}", Cena = g?.Cena ?? 0 })
                 .GroupBy(x => x.Autor)
                 .Select(x => new { Autor = x.Key, Cena = x.Sum(y => y.Cena) });

            foreach (var i in lista)
                Console.WriteLine(i);
        }
    }
}
