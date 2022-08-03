using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class ParaInt
    {
        public int Pierwszy { get; }
        public int Drugi { get; }

        public ParaInt(int pierwszy, int drugi)
        {
            Pierwszy = pierwszy;
            Drugi = drugi;
        }
    }

    class Para<T>
    {
        public T Pierwszy { get; }
        public T Drugi { get; }

        public Para(T pierwszy, T drugi)
        {
            Pierwszy = pierwszy;
            Drugi = drugi;
        }
    }

    class Osoba
    {
        public string Imie { get; set; }
        public string Nazwiskio { get; set; }

    }

    class A
    {
        public A(int a)
        {

        }
    }

    class Klasa<T> where T : class, new()
    {
        public T Wartosc { get; }

        public Klasa()
        {
            Wartosc = new();
        }

        public Klasa(T t)
        {
            Wartosc = t;
        }

        public T NowaWartosc()
        {
            return new();
        }
    }

    class Osoba1 : IComparable<Osoba1>
    {
        public string Imie { get; set;}
        public string Nazwiskio { get; set;}
        public int Wiek { get; set;}

        public int CompareTo(Osoba1 other)
        {
            if(this.Wiek < other.Wiek)
                return -1;
            else if (this.Wiek > other.Wiek)
                return 1;
            else
                return 0;
        }
    }

    class Element
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public Element(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }


    class Kolekcja
    {
        private List<Element> elements;

        public Kolekcja()
        {
            elements = new List<Element>();
        }

        public void Dodaj(string name, object element)
        {
            elements.Add(new Element(name, element));
        }

        public object Pobierz<T>(string name)
        {
            var e = elements.FindAll(x => x.Name == name);
            var element = e.Find(x => x.Value.GetType() == typeof(T));
            return element?.Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*var klasa = new Klasa<Osoba>(new Osoba() { Imie = "Ala", Nazwiskio = "Kot" });
            Osoba osoba = klasa.Wartosc;
            Osoba o2 = klasa.NowaWartosc();
            ParaInt p1 = new ParaInt(2, 8);
            Para<int> p2 = new Para<int>(2, 8);
            int w1 = 0, w2 = 0;
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            for(int i = 0; i < 100000000; i++)
            {
                w1 += p1.Pierwszy;
                w1 += p1.Drugi;
            }
            sw1.Stop();
            Console.WriteLine($"Time paraint = {sw1.Elapsed}");

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            for (int i = 0; i < 100000000; i++)
            {
                w2 += p2.Pierwszy;
                w2 += p2.Drugi;
            }
            sw2.Stop();
            Console.WriteLine($"Time para<int> = {sw2.Elapsed}");*/

            var kolekcja = new Kolekcja();

            kolekcja.Dodaj("imie", "Ala");
            kolekcja.Dodaj("imie", 1);

            Console.WriteLine(kolekcja.Pobierz<string>("imie"));
            Console.WriteLine(kolekcja.Pobierz<int>("imie"));


        }
    }
}
