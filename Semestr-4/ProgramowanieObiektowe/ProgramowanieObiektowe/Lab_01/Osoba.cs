using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal class Osoba
    {
        string imie, nazwisko, adresZamieszkania;
        private int liczbaSamochodow = 0;
        readonly string[] samochody;

        public string Imie
        {
            get => imie;
            set => imie = value;
        }
        public string Nazwisko
        {
            get => nazwisko;
            set => nazwisko = value;
        }
        public string AdresZamieszkania
        {
            get => adresZamieszkania;
            set => adresZamieszkania = value;
        }

        public Osoba()
        {
            imie = "nieznane";
            nazwisko = "nieznane";
            adresZamieszkania = "nieznany";
            samochody = null;
        }
        public Osoba(string imie, string nazwisko, string adresZamieszkania, int liczbaSamochodow)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.adresZamieszkania = adresZamieszkania;
            if(liczbaSamochodow > 3)
            {
                samochody = new string[3];
                return;
            }
            else if(liczbaSamochodow <= 0)
            {
                samochody = null;
                return;
            }
            samochody = new string[liczbaSamochodow];
        }

        public void DodajSamochod(string numer)
        {
            if (samochody is null)
            {
                Console.WriteLine($"{imie} {nazwisko} nie moze posiadac żadnych samochodow");
                return;
            }
            if (liczbaSamochodow >= 3)
            {
                Console.WriteLine($"{imie} {nazwisko} nie moze posiadac wiecej samochodow");
                return;
            }
            
            liczbaSamochodow++;
            var index = Array.FindIndex(samochody, nr => nr == null);
            if (index == -1)
            {
                Console.WriteLine($"{imie} {nazwisko} nie moze posiadac wiecej samochodow");
                return;
            }
            samochody[index] = numer;
        }

        public void UsunSamochod(string numer)
        {
            if (samochody is null)
            {
                Console.WriteLine($"{imie} {nazwisko} nie moze posiadac żadnych samochodow");
                return;
            }
            if (liczbaSamochodow == 0)
            {
                Console.WriteLine($"{imie} {nazwisko} nie posiada samochodow");
                return;
            }
            var index = Array.FindIndex(samochody, n => n == numer);
            if (index == -1)
            {
                Console.WriteLine("Nie ma takiego samochodu");
                return;
            }
            liczbaSamochodow--;
            samochody[index] = null;
        }

        public void WypiszInfo()
        {
            Console.WriteLine(this.GetType().Name);
            Console.WriteLine($"\tImie: {imie}");
            Console.WriteLine($"\tNazwisko: {nazwisko}");
            Console.WriteLine($"\tAdres: {adresZamieszkania}");
            Console.WriteLine($"\tIlosc samochodow: {liczbaSamochodow}");
            if (liczbaSamochodow == 0)
            {
                Console.WriteLine($"\tNie posiada zadnych samochodow");
                return;
            }
            foreach (string s in samochody)
            {
                if (s is null) continue;
                Console.WriteLine($"\t\t{s}");
            }
        }
    }
}
