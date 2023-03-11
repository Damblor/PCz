using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class Osoba
    {
        protected string imie, nazwisko, dataUrodzenia;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        protected string DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }

        public Osoba()
        {
            imie = "nieznane";
            nazwisko = "nieznane";
            dataUrodzenia = "nieznana";
        }

        public Osoba(string imie, string nazwisko, string dataUrodzenia)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dataUrodzenia = dataUrodzenia;
        }

        public virtual void WypiszInfo()
        {
            Console.WriteLine($"Klasa {this.GetType().Name}");
            Console.WriteLine($"\tImie: {imie}\n\tNazwisko: {nazwisko}\n\tData Urodzenia: {dataUrodzenia}");
        }

    }
}
