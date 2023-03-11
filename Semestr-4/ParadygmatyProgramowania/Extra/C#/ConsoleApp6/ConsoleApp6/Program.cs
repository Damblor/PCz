using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ksiazki = new[]
            {
                new Ksiazka {Tytul = "Pan Tadeusz", RokWydana = 1998, Gatunek = 1, Cena = 30},
                new Ksiazka {Tytul = "Potop", RokWydana = 1991, Gatunek = 1, Cena = 40},
                new Ksiazka {Tytul = "W pustyni i w puszczy", RokWydana = 1990, Gatunek = 2, Cena = 30},
                new Ksiazka {Tytul = "Lalka", RokWydana = 1990, Gatunek = 1, Cena = 50},
                new Ksiazka {Tytul = "Programowanie funkcyjne w jezyku c#", RokWydana = 2019, Gatunek = 3, Cena = 71.20},
                new Ksiazka {Tytul = "Programowanie funkcyjne z JavaScriptem", RokWydana = 2017, Gatunek = 3, Cena = 29.40},
            };

            var gatunki = new[]
            {
                new Gatunek { id = 1, Nazwa = "Literatura piękna" },
                new Gatunek { id = 2, Nazwa = "Przygodowa" },
                new Gatunek { id = 3, Nazwa = "Programowanie" },
                new Gatunek { id = 4, Nazwa = "Projektowanie stron WWW" },
            };

            var laczna_cena =
                (from g in gatunki
                 join k in ksiazki on g.id equals k.Gatunek
                 into grupy
                 from gg in grupy.DefaultIfEmpty()
                 select new { Gatunek = g.Nazwa, LacznaCena = gg?.Cena ?? 0 })
                 .GroupBy(x => x.Gatunek)
                 .Select(x => new { Gatunek = x.Key, LacznaCena = x.Sum(y => y.LacznaCena) });

            foreach (var l in laczna_cena)
                Console.WriteLine(l);
        }
    }

    public class Ksiazka
    {
        public string Tytul { get; set; }
        public int RokWydana { get; set; }
        public int Gatunek { get; set; }
        public double Cena { get; set; }

        public Ksiazka() { }
    }

    public class Gatunek
    {
        public int id { get; set; }
        public string Nazwa { get; set; }
        
        public Gatunek() { }
    }
}
