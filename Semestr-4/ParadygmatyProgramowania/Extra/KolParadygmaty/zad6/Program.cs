using System;
using System.Linq;

namespace Zad6
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var punkty = new[]
            {
                new Punkt(4, 2),
                new Punkt(-3, 4),
                new Punkt(5, 6),
                new Punkt(7, -8),
                new Punkt(-3, 4),
                new Punkt(5, 6),
                new Punkt(7, -8),
                new Punkt(-9, -10),
                new Punkt(-3, 4),
                new Punkt(5, 6),
                new Punkt(4, -8),
                new Punkt(-9, -10),
                new Punkt(-39, 11),
            };



            var cwiartki =
                (from p in punkty
                 select new { Cwiartka = GetCwiartka(p), Punkt = $"({p.X},{p.Y})" })
                 .GroupBy(x => x.Cwiartka)
                 .Select(y => new { Cwiartka = y.Key, Punkty = y.Count() })
                 .OrderByDescending(z => z.Cwiartka);

            foreach (var p in cwiartki)
            {
                Console.WriteLine(p);
            }
        }

        public static int GetCwiartka(Punkt punkt)
        {
            if (punkt.X > 0 && punkt.Y > 0)
                return 1;
            else if (punkt.X < 0 && punkt.Y > 0)
                return 2;
            else if (punkt.X < 0 && punkt.Y < 0)
                return 3;
            else if (punkt.X > 0 && punkt.Y < 0)
                return 4;
            else
                return 5;
        }
    }

    public class Punkt
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Punkt() { }

        public Punkt(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
