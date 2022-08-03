using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal class Zad1
    {
        private readonly List<Osoba> osoby = new List<Osoba>();
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Wybierz opcje: ");
                Console.WriteLine("0.Wyjscie\n" +
                    "1.Stworz osobe\n" +
                    "2.Edytuj osobe\n" +
                    "3.Wyswietl osoby");
                Console.Write(">");

                int w;
                while (!int.TryParse(Console.ReadLine(), out w))
                {
                    Console.WriteLine("Niepoprawna wartosc");
                }
                switch (w)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        return;
                    case 1:
                        CreatePerson();
                        break;
                    case 2:
                        EditPerson();
                        break;
                    case 3:
                        ShowPersons();
                        break;
                    default:
                        Console.WriteLine("===Wybrano bledny tryb===");
                        break;
                }
            }
        }

        private void CreatePerson()
        {
            Console.WriteLine("Podaj imie:");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko:");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj adres:");
            string adres = Console.ReadLine();
            int liczba;
            Console.WriteLine("Podaj liczbe samochodow:");
            while(!int.TryParse(Console.ReadLine(),out liczba))
            {
                Console.WriteLine("Bledna liczba");
            }
            Osoba os = new Osoba(imie, nazwisko, adres, liczba);
            for(int i = 0; i < liczba; i++)
            {
                Console.WriteLine("Podaj numer rejestracyjny:");
                string numer = Console.ReadLine();
                os.DodajSamochod(numer);
            }
            osoby.Add(os);
        }
        private void EditPerson()
        {
            Console.WriteLine("Wybierz osobe:");
            for(int i = 0; i < osoby.Count; i++)
            {
                Console.WriteLine($"{i}.{osoby[i].Imie} {osoby[i].Nazwisko}");
            }
            int o;
            while (!int.TryParse(Console.ReadLine(), out o))
            {
                Console.WriteLine("Bledna opcja");
            }
            int l;
            Console.WriteLine("0.Wyjscie\n" +
                "1.Dodaj samochod\n" +
                "2.Usun samochod\n" +
                "3.Edytuj dane\n" +
                "4.Usun osobe");
            while (!int.TryParse(Console.ReadLine(), out l))
            {
                Console.WriteLine("Bledna opcja");
            }

            switch(l)
            {
                case 0:
                    return;
                case 1:
                    Dodaj();
                    break;
                case 2:
                    Usun();
                    break;
                case 3:
                    Edytuj();
                    break;
                case 4:
                    UsunOs();
                    break;
                default:
                    return;
            }

            void Dodaj()
            {
                Console.WriteLine("Podaj numer rejestracyjny: ");
                string numer = Console.ReadLine();
                osoby[o].DodajSamochod(numer);
            }

            void Usun()
            {
                Console.WriteLine("Podaj numer rejestracyjny: ");
                string numer = Console.ReadLine();
                osoby[o].UsunSamochod(numer);
            }

            void Edytuj()
            {
                Console.WriteLine("Podaj imie:");
                string imie = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko:");
                string nazwisko = Console.ReadLine();
                Console.WriteLine("Podaj adres:");
                string adres = Console.ReadLine();
                osoby[o].Imie = imie;
                osoby[o].Nazwisko = nazwisko;
                osoby[o].AdresZamieszkania = adres;
            }

            void UsunOs()
            {
                osoby.Remove(osoby[o]);
            }
        }
        private void ShowPersons()
        {
            foreach (var osoba in osoby)
                osoba.WypiszInfo();
        }
    }
}
