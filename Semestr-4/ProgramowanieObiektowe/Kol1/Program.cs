using System;
using System.Collections.Generic;

//Autor: Piotr Krupa 133496 gr.lab.1

namespace Kol1
{
    public abstract class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public override string ToString()
        {
            return $"Imie: {Imie} Nazwisko: {Nazwisko}";
        }

        public abstract void WypiszInfo();
    }

    public class Kurier : Osoba
    {
        public int NrId { get; set; }

        private List<Paczka> listaPaczekDoDostarczenia;

        public Kurier(string imie, string nazwisko, int nrId)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            NrId = nrId;
            listaPaczekDoDostarczenia = new List<Paczka>();
        }

        public void DodajPaczke(Paczka paczka)
        {
            if (listaPaczekDoDostarczenia.Contains(paczka))
            {
                Console.WriteLine("Kurier już posiada paczke");
                return;
            }
            listaPaczekDoDostarczenia.Add(paczka);
        }

        public void DostarczPaczke(Odbiorca odbiorca)
        {
            List<Paczka> paczkiDoDostarczenia = listaPaczekDoDostarczenia.FindAll(z => z.Odbiorca == odbiorca);

            List<Paczka> dostarczonePaczki = odbiorca.OdbierzPaczki(paczkiDoDostarczenia);
            foreach(var p in dostarczonePaczki)
            {
                if(listaPaczekDoDostarczenia.Contains(p as Paczka))
                {
                    listaPaczekDoDostarczenia.Remove(p as Paczka);
                    Magazyn.IloscPaczekWObiegu--;
                }
            }
        }

        public void WypiszPaczki(Odbiorca odbiorca)
        {
            List<Paczka> paczkiOdbiorycy = listaPaczekDoDostarczenia.FindAll(z => z.Odbiorca == odbiorca);
            if (paczkiOdbiorycy.Count == 0)
            {
                Console.WriteLine("Kurier nie ma paczek dla " + odbiorca.ToString());
                return;
            }
            Console.WriteLine("Paczki u kuriera dla " + odbiorca.ToString());
            foreach (var paczka in paczkiOdbiorycy)
            {
                paczka.WypiszInfo();
            }
        }

        public void WypiszPaczki()
        {
            if (listaPaczekDoDostarczenia.Count == 0)
            {
                Console.WriteLine("Kurier nie posiada paczek");
                return;
            }
            Console.WriteLine("Paczki u kuriera:");
            foreach (var paczka in listaPaczekDoDostarczenia)
                paczka.WypiszInfo();
        }

        public override string ToString()
        {
            return $"{base.ToString()} NrId: {NrId}";
        }

        public override void WypiszInfo()
        {
            Console.WriteLine(this);
        }
    }

    public class Odbiorca : Osoba
    {
        public string AdresZamieszkania { get; set; }

        private List<Paczka> zamowionePaczki;

        public Odbiorca(string imie, string nazwisko, string adres)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            AdresZamieszkania = adres;
            zamowionePaczki = new List<Paczka>();
        }

        public void ZamowPaczke(Paczka paczka)
        {
            if(zamowionePaczki.Contains(paczka))
            {
                Console.WriteLine(this + " juz zamowila ta paczke");
            }
            else
            {
                zamowionePaczki.Add(paczka);
            }
        }

        public List<Paczka> OdbierzPaczki(List<Paczka> paczki)
        {
            List<Paczka> odebranepaczki = new List<Paczka>();
            foreach(var paczka in paczki)
            {
                if (zamowionePaczki.Contains(paczka))
                {
                    zamowionePaczki.Remove(paczka);
                    odebranepaczki.Add(paczka);
                }
                else
                {
                    Console.WriteLine("Osoba nie zamawiała tej przesyłki");
                }
            }
            return odebranepaczki;
        }

        public override void WypiszInfo()
        {
            Console.WriteLine(this);
        }
    }

    public class Paczka
    {
        public int ID { get; set; }

        public Odbiorca? Odbiorca { get; set; }

        public Paczka()
        {
            ID = 0;
            Odbiorca = null;
        }

        public Paczka(int id)
        {
            ID = id;
            Odbiorca = null;
        }

        public Paczka(int id, Odbiorca odbiorca)
        {
            ID = id;
            Odbiorca = odbiorca;
        }

        public void WypiszInfo()
        {
            Console.WriteLine(this);
            if(Odbiorca is null)
            {
                Console.WriteLine("Brak odbiorcy");
            }
            else
            {
                Console.WriteLine(Odbiorca);
            }
        }

        public override string ToString()
        {
            return $"Id paczki: {ID}";
        }
    }

    public class Magazyn : IZarzadzanieMagazynem
    {
        public static int IloscPaczekWObiegu = 0;

        public string Adres { get; set; }

        private List<Paczka> paczkiWMagazynie;

        private List<Kurier> listaKurierow;

        public Magazyn(string adres)
        {
            Adres = adres;
            paczkiWMagazynie = new List<Paczka>();
            listaKurierow = new List<Kurier>();
        }

        public void DodajKuriera(Kurier kurier)
        {
            if(listaKurierow.Contains(kurier))
            {
                Console.WriteLine("Kurier jest juz zatrudniony");
                return;
            }
            listaKurierow.Add(kurier);
        }

        public void DodajPaczke(Paczka paczka)
        {
            if (paczkiWMagazynie.Contains(paczka))
            {
                Console.WriteLine("Paczka już jest w systemie");
                return;
            }
            paczkiWMagazynie.Add(paczka);
            IloscPaczekWObiegu++;
        }

        public void PrzekarzPaczke(Paczka paczka, Kurier kurier)
        {
            if(listaKurierow.Contains(kurier))
            {
                if (paczkiWMagazynie.Contains(paczka))
                {
                    paczkiWMagazynie.Remove(paczka);
                    kurier.DodajPaczke(paczka);
                }
                else
                {
                    Console.WriteLine("Paczki nie ma w magazyne");
                }
            }
            else
            {
                Console.WriteLine("Kurier nie istnieje");
            }
        }

        public void UsunPaczkiBezOdbiorcy()
        {
            List<Paczka> paczkiBezOdbiorcy = paczkiWMagazynie.FindAll(z => z.Odbiorca is null);

            foreach(var paczka in paczkiBezOdbiorcy)
            {
                if(paczkiWMagazynie.Contains(paczka))
                {
                    paczkiWMagazynie.Remove(paczka);
                    IloscPaczekWObiegu--;
                }
            }
        }

        public void WypiszPaczki(Odbiorca odbiorca)
        {
            List<Paczka> paczkiOdbiorycy = new List<Paczka>();
            foreach(var paczka in paczkiWMagazynie)
            {
                if(paczka.Odbiorca is null)
                {
                    continue;
                }
                if(paczka.Odbiorca.Equals(odbiorca))
                {
                    paczkiOdbiorycy.Add(paczka);
                }
            }
            if(paczkiOdbiorycy.Count == 0)
            {
                Console.WriteLine("Nie ma paczek dla" + odbiorca.ToString());
                return;
            }
            Console.WriteLine("Paczki w magazynie dla " + odbiorca.ToString());
            foreach (var paczka in paczkiOdbiorycy)
            {
                paczka.WypiszInfo();
            }
        }

        public void WypiszPaczki()
        {
            if(paczkiWMagazynie.Count == 0)
            {
                Console.WriteLine("Brak paczek w magazynie");
                return;
            }
            Console.WriteLine("Paczki w magazynie:");
            foreach (var paczka in paczkiWMagazynie)
                paczka.WypiszInfo();
        }

        public void WypiszPracownikow()
        {
            if (listaKurierow.Count == 0)
            {
                Console.WriteLine("Brak pracownikow");
                return;
            }
            Console.WriteLine("Pracownicy:");
            foreach (var pracownik in listaKurierow)
                pracownik.WypiszInfo();
        }

        public void WypiszInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Adres magazynu: {Adres}";
        }

        public static void WypiszLiczbePaczekWObiegu()
        {
            Console.WriteLine(IloscPaczekWObiegu);
        }
    }

    public interface IZarzadzanieMagazynem
    {
        public void DodajPaczke(Paczka paczka);
        public void PrzekarzPaczke(Paczka paczka, Kurier kurier);
        public void WypiszPaczki();
        public void WypiszPaczki(Odbiorca odbiorca);
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Magazyn.WypiszLiczbePaczekWObiegu();
            Magazyn magazyn = new Magazyn("ul. Laczna");
            magazyn.WypiszPaczki();
            magazyn.WypiszPracownikow();
            magazyn.WypiszInfo();

            Kurier k1 = new Kurier("Marek", "Biesczad", 12);
            Kurier k2 = new Kurier("Krystian", "Mielasz", 0);

            k1.WypiszPaczki();
            k1.WypiszInfo();

            magazyn.DodajKuriera(k1);
            magazyn.WypiszPracownikow();

            Odbiorca o1 = new Odbiorca("Pawel", "Kas", "ul. Sloneczna");
            Odbiorca o2 = new Odbiorca("Zbyszek", "Potocki", "al. Bohaterow");

            Paczka p1 = new Paczka();
            Paczka p2 = new Paczka(13);
            Paczka p3 = new Paczka(12, o1);
            Paczka p4 = new Paczka(22, o1);
            Paczka p5 = new Paczka(54, o1);
            Paczka p6 = new Paczka(3, o2);
            Paczka p7 = new Paczka(31, o2);

            o1.ZamowPaczke(p3);
            o1.ZamowPaczke(p4);
            o1.ZamowPaczke(p5);

            magazyn.DodajPaczke(p1);
            magazyn.DodajPaczke(p1);
            magazyn.DodajPaczke(p2);
            magazyn.DodajPaczke(p3);
            magazyn.DodajPaczke(p4);
            magazyn.DodajPaczke(p5);
            magazyn.DodajPaczke(p6);
            magazyn.DodajPaczke(p7);

            Console.WriteLine("==========");
            magazyn.WypiszPaczki();
            Magazyn.WypiszLiczbePaczekWObiegu();

            Console.WriteLine("==========");
            magazyn.WypiszPaczki(o1);

            Console.WriteLine("==========");
            magazyn.PrzekarzPaczke(p3,k1);
            magazyn.PrzekarzPaczke(p4, k1);
            magazyn.PrzekarzPaczke(p5, k2);
            magazyn.PrzekarzPaczke(p7, k1);

            magazyn.WypiszPaczki();
            Magazyn.WypiszLiczbePaczekWObiegu();
            Console.WriteLine("==========");
            k1.WypiszPaczki();
            k2.WypiszPaczki();

            Console.WriteLine("==========");
            k1.DostarczPaczke(o1);
            k1.WypiszPaczki();
            Magazyn.WypiszLiczbePaczekWObiegu();

            Console.WriteLine("==========");
            Magazyn.WypiszLiczbePaczekWObiegu();
            magazyn.WypiszPaczki();
            magazyn.UsunPaczkiBezOdbiorcy();

            Magazyn.WypiszLiczbePaczekWObiegu();
            magazyn.WypiszPaczki();


        }
    }
}
