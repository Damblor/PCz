using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal class Osoba
    {
        private string imie, nazwisko;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }

        public Osoba()
        {
            imie = "neiznane";
            nazwisko = "nieznane";
        }
        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public virtual void WypiszInfo()
        {
            Console.WriteLine($"\t{Imie} {Nazwisko}");
        }
    }
}
