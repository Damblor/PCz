using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    internal class Student : Osoba, IWyswietlinfo
    {
        public int Grupa { get; set; }
        public int NumerIndeksu { get; set; }
        public int Rok { get; set; }
        public string Specjalizacja { get; set; }
        public IList<OcenaKoncowa> OcenyKoncowe { get; set; }

        public Student() : base()
        {
            Grupa = 0;
            NumerIndeksu = 0;
            Rok = 0;
            Specjalizacja = string.Empty;
            OcenyKoncowe = new List<OcenaKoncowa>();
        }
        public Student(string imie, string nazwisko, DateTime dataUrodzin, int grupa, int numerIndeksu, string specjalizacja, int rok)
            : base(imie,nazwisko,dataUrodzin)
        {
            Grupa = grupa;
            NumerIndeksu = numerIndeksu;
            Rok = rok;
            Specjalizacja = specjalizacja;
            OcenyKoncowe = new List<OcenaKoncowa>();
        }

        public void DodajOcene(OcenaKoncowa ocena)
        {
            if(OcenyKoncowe.Contains(ocena))
            {
                Console.WriteLine("Oceja juz istnieje");
                return;
            }
            OcenyKoncowe.Add(ocena);
        }
        public void DodajOcene(Przedmiot przedmiot, double wartosc, DateTime data)
        {
            OcenaKoncowa ocena = new(przedmiot, wartosc, data);
            if (OcenyKoncowe.Contains(ocena))
            {
                Console.WriteLine("Oceja juz istnieje");
                return;
            }
            OcenyKoncowe.Add(ocena);
        }
        public void UsunOcene(OcenaKoncowa ocena)
        {
            if (!OcenyKoncowe.Contains(ocena))
            {
                Console.WriteLine("Oceja nie istnieje");
                return;
            }
            OcenyKoncowe.Remove(ocena);
        }
        public void UsunOceny()
        {
            OcenyKoncowe.Clear();
        }

        public override string ToString()
        {
            return $"{base.ToString()} Grupa: {Grupa} Numer indeksu: {NumerIndeksu} Rok: {Rok} Specjalizacja: {Specjalizacja}";
        }
        public override void Wyswietlinfo()
        {
            Console.WriteLine(this);
            Console.WriteLine($"Liczba ocen: {OcenyKoncowe.Count}");
            WyswietlOceny();
        }
        public void WyswietlOceny()
        {
            foreach(var ocena in OcenyKoncowe)
                ocena.Wyswietlinfo();
        }
    }
}
