using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    internal class Osoba : IWyswietlinfo
    {
        public DateTime DataUrodzin { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Osoba()
        {
            Imie = string.Empty;
            Nazwisko = string.Empty;
            DataUrodzin = DateTime.Now;
        }
        public Osoba(string imie, string nazwisko, DateTime dataUrodzin)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzin = dataUrodzin;
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {DataUrodzin}";
        }

        public virtual void Wyswietlinfo()
        {
            Console.WriteLine(this);
        }
    }
}
