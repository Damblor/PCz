using System;
using System.Linq;

namespace Zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wyrazy = new[]
            {
                "Paradygmaty",
                "programowanie",
                "obiektowe",
                "niskopoziomowe",
                "Czwarty",
                "drugi",
                "grafika",
                "gruszka",
                "cytryna",
                "czarny",
            };

            var liczbaWyrazowZaczynajaca =
                (from wyraz in wyrazy
                 group wyraz by char.ToUpper(wyraz[0]) into grupa
                 select new { Litera = grupa.Key, Ilosc = grupa.Count() });
            foreach (var w in liczbaWyrazowZaczynajaca)
            {
                Console.WriteLine(w);
            }
        }
    }
}
