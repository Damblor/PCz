using System;
using System.Collections.Generic;
using System.Linq;

namespace x
{
    public class Autor
    {
        public int id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

    }
    public class Ksiazka
    {
        public string Tytul { get; set; }
        public int RokWydania { get; set; }
        public int Autor { get; set; }
        public double Cena { get; set; }
    }

    public class DrzewoBinarne
    {
        public int Value { get; private set; }
        public DrzewoBinarne Left { get; private set; }
        public DrzewoBinarne Right { get; private set; }

        public DrzewoBinarne(int value)
        {
            Value = value;
        }

        public void Add(int value)
        {
            if (value < Value)
            {
                if (Left == null)
                    Left = new DrzewoBinarne(value);
                else
                    Left.Add(value);
            }
            else
            {
                if (Right == null)
                    Right = new DrzewoBinarne(value);
                else
                    Right.Add(value);
            }
        }

        public int Suma()
        {
            return Value + 
                (Left == null ? 0 : Left.Suma()) + 
                (Right == null ? 0 : Right.Suma());
        }
    }

    static class Program
    {
        static void Zadanie1()
        {
            var ksiazki = new[] {

            new Ksiazka {Tytul = "Pan Tadeusz", RokWydania = 1998, Autor = 1, Cena = 30},

            new Ksiazka {Tytul = "Potop", RokWydania = 1991, Autor = 2, Cena = 40},

            new Ksiazka {Tytul = "W pustyni i w puszczy", RokWydania = 1990, Autor = 2, Cena = 30},

            new Ksiazka {Tytul = "Lalka", RokWydania = 1990, Autor = 3, Cena = 50},

            new Ksiazka {Tytul = "Programowanie funkcyjne w języku C#", RokWydania = 2019, Autor = 4, Cena = 71.20},

            new Ksiazka {Tytul = "Programowanie funkcyjne z JavaScriptem", RokWydania = 2017, Autor = 5, Cena = 29.40},

            };

            var autorzy = new[] {

            new Autor { id = 1, Imie = "Adam", Nazwisko = "Mickiewicz" },

            new Autor { id = 2, Imie = "Henryk", Nazwisko = "Sienkiewicz" },

            new Autor { id = 3, Imie = "Bolesław", Nazwisko = "Prus" },

            new Autor { id = 4, Imie = "Enrico", Nazwisko = "Buonanno" },

            new Autor { id = 5, Imie = "Luis", Nazwisko = "Atencio" },

            new Autor { id = 6, Imie = "Robert C.", Nazwisko = "Martin" },

            };

            /*var lista =
                (from a in autorzy
                 join k in ksiazki
                     on a.id equals k.Autor select new { Autor = $"{a.Imie} {a.Nazwisko}", Cena = k?.Cena ?? 0 })
                     .GroupBy(x => x.Autor)
                     .Select(autor => new { Autor = autor.Key, Min = autor.Min(a => a.Cena) });*/

            /*var lista =
                (from autor_cena in (from a in autorzy
                     join k in ksiazki on a.id equals k.Autor
                     into grupy
                     from g in grupy.DefaultIfEmpty()
                     select new { Autor = $"{a.Imie} {a.Nazwisko}", Cena = g?.Cena ?? 0 })
                 group autor_cena by autor_cena.Autor into grupa
                 select new { Autor = grupa.Key, Min = grupa.Min(a => a.Cena) }
                 );*/

            var lista =
                (from a in autorzy
                 join k in ksiazki on a.id equals k.Autor
                 into grupy
                 from g in grupy.DefaultIfEmpty()
                 select new { Autor = $"{a.Imie} {a.Nazwisko}", Cena = g?.Cena ?? 0 })
                 .GroupBy(x => x.Autor)
                 .Select(x => new { Autor = x.Key, Cena = x.Min(a => a.Cena) });

            foreach (var l in lista)
                Console.WriteLine(l);
        }

        static void Zadanie2()
        {
            var drzewo = new DrzewoBinarne(2);
            drzewo.Add(1);
            drzewo.Add(3);
            drzewo.Add(2);
            drzewo.Add(1);

            Console.WriteLine(drzewo.Suma());
        }

        static void Zadanie3()
        {
            var pofiltorwane =
                (from punkt in GenerujPunkty()
                 where Math.Sin(punkt.Item1) < punkt.Item2
                 select punkt);

            foreach (var (x, y) in pofiltorwane)
            {
                Console.WriteLine($"{x} {y}");
            }
        }
        
        static IEnumerable<Tuple<double, double>> GenerujPunkty()
        {
            for (double x = -10.0; x <= 10.0; x+=0.1)
            {
                yield return new Tuple<double, double>(x, 0.5);
            }
        }

        static IEnumerable<Tuple<int, int, int>> Generuj3D()
        {
            Random r = new Random();

            while (true)
            {
                var ret = new Tuple<int, int, int>(r.Next(-10, 10), r.Next(-10, 10), r.Next(-10, 10));
                Console.WriteLine(ret);
                yield return ret;
            }
        }

        static IEnumerable<Tuple<int, int, int>> PrzerwanieGenerowania3D(this IEnumerable<Tuple<int, int, int>> points)
        {
            foreach (var point in points)
            {
                if (point.Item3 == 5)
                {
                    yield break;
                }
                yield return point;
            }
        }

        static Tuple<int, int, int> SumaSkladowych(this IEnumerable<Tuple<int, int, int>> points)
        {
            var ret = new Tuple<int, int, int>(0, 0, 0);
            foreach (var (x,y,z) in points)
            {
                ret = new Tuple<int, int, int>(
                    ret.Item1 + x,
                    ret.Item2 + y,
                    ret.Item3 + z);
            }
            return ret;
        }

        static int Silnia(this int n)
        {
            if (n <= 1) return 1;
            return n * Silnia(n - 1);
        }

        class Lista<T> where T : IComparable<T>, new()
        {
            public T Value { get; }
            public Lista<T> Next { get; }

            public Lista(T value, Lista<T> next)
            {
                Value = value;
                Next = next;
            }

            public int Dodatnie()
            {
                return
                    (Next == null ? 0 : Next.Dodatnie()) +
                    (Value.CompareTo(new T()) > 0 ? 1 : 0);
            }

            public T Min()
            {
                if (Next == null)
                    return Value;
                else {
                    var nextMin = Next.Min();
                    return nextMin.CompareTo(Value) < 0 ? nextMin : Value;
                }
            }
        }

        static IEnumerable<Tuple<double, double>> GenerujPunkty(double xMax, double yMax, int count)
        {
            Random r = new Random();

            for (int i = 0; i < count; ++i)
            {
                yield return new Tuple<double, double>(xMax * (2.0 * r.NextDouble() - 1.0), yMax * (2.0 * r.NextDouble() - 1.0));
            }
        }

        static void Main(string[] args)
        {
            /*foreach(var l in LiczbyOdUsera().Tylko(x => x >= 5 && x <= 10))
            {
                Console.WriteLine(l);
            }*/

            /*Console.WriteLine(
                Generuj3D().PrzerwanieGenerowania3D().SumaSkladowych()
                );

            Console.WriteLine(10.Silnia());

            var lista = new Lista<int>(1, new Lista<int>(2, new Lista<int>(-1, new Lista<int>(0, new Lista<int>(5, null)))));
            Console.WriteLine(lista.Dodatnie());
            Console.WriteLine(lista.Min());*/

            int Cwiartka(Tuple<double, double> punkt)
            {
                var (x, y) = punkt;

                if (x > 0 && y > 0)
                    return 1;
                else if (x < 0 && y > 0)
                    return 2;
                else if (x < 0 && y < 0)
                    return 3;
                else if (x > 0 && y < 0)
                    return 4;
                else
                    return 5;
            }

            var punkty =
                (from punkt in GenerujPunkty(10, 10, 13)
                 select new { Cwiartka = Cwiartka(punkt), Punkt = punkt }).OrderBy(x => x.Cwiartka).ToList();
            foreach (var p in punkty)
            {
                Console.WriteLine(p);
            }

            var wyrazy = new[]
            {
                "kotlet",
                "Krzysztof",
                "gruby",
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

        public static IEnumerable<int> Tylko(this IEnumerable<int> enumerator, Func<int, bool> predykat)
        {
            foreach (var i in enumerator)
            {
                if (predykat(i))
                    yield return i;
            }
        }

        public static IEnumerable<int> LiczbyOdUsera()
        {
            while (true)
            {
                int x;
                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch
                {
                    yield break;
                }                
                yield return x;
            }
        }
    }
}
