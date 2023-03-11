using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    internal class Przedmiot : IWyswietlinfo
    {
        public int LiczbaGodzin { get; set; }
        public string Nazwa { get; set; }
        public int Semestr { get; set; }
        public string Specjalizacja { get; set; }

        public Przedmiot(int liczbaGodin, string nazwa, int semestr, string specjalizacja)
        {
            LiczbaGodzin = liczbaGodin;
            Nazwa = nazwa;
            Semestr = semestr;
            Specjalizacja = specjalizacja;
        }

        public override string ToString()
        {
            return $"{Nazwa} Specjalizacja: {Specjalizacja} Semestr: {Semestr} Liczba godzin: {LiczbaGodzin}";
        }
        public void Wyswietlinfo()
        {
            Console.WriteLine(this);
        }
    }
}
