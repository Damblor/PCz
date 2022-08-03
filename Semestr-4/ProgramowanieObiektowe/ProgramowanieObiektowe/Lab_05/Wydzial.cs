using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    internal class Wydzial : IWyswietlinfo
    {
        public Osoba Dziekan { get; set; }
        public IList<JednostkaOrganizacyjna> JednostkiOrganizacyjne { get; set; }
        public string Nazwa { get; set; }
        public IList<Przedmiot> Przedmioty { get; set; }
        public IList<Student> Studenci { get; set; }

        public Wydzial(string nazwa, Osoba dziekan, IList<Student> studenci = null, IList<Przedmiot> przedmioty = null, IList<JednostkaOrganizacyjna> jednostkiOrganizacyjne = null)
        {
            Nazwa = nazwa;
            Dziekan = dziekan;
            JednostkiOrganizacyjne = new List<JednostkaOrganizacyjna>();
            Przedmioty = new List<Przedmiot>();
            Studenci = new List<Student>();
        }

        public void DodajJednostkeOrganizacyjna(JednostkaOrganizacyjna jednostkaOrganizacyjna)
        {
            if(JednostkiOrganizacyjne.Contains(jednostkaOrganizacyjna))
            {
                Console.WriteLine("Jednostka organizacyjna już istnieje");
                return;
            }
            JednostkiOrganizacyjne.Add(jednostkaOrganizacyjna);
        }

        public void DodajPrzedmiot(Przedmiot przedmiot)
        {
            if (Przedmioty.Contains(przedmiot))
            {
                Console.WriteLine("Przedmiot już istnieje");
                return;
            }
            Przedmioty.Add(przedmiot);
        }

        public void DodajStudenta(Student student)
        {
            if (Studenci.Contains(student))
            {
                Console.WriteLine("Student już istnieje");
                return;
            }
            Studenci.Add(student);
        }

        public void DodajWykladowce(Wykladowca wykladowca, JednostkaOrganizacyjna jednostkaOrganizacyjna)
        {
            if(JednostkiOrganizacyjne.Contains(jednostkaOrganizacyjna))
            {
                var index = JednostkiOrganizacyjne.IndexOf(jednostkaOrganizacyjna);
                JednostkiOrganizacyjne.ElementAt(index).DodajWyladowce(wykladowca);
                return;
            }
            Console.WriteLine("Jednostka organizacyjna nie istnieje");
        }

        public void PrzeniesWykladowce(Wykladowca wykladowca, JednostkaOrganizacyjna jednostkaOrganizacyjnaStara, JednostkaOrganizacyjna jednostkaOrganizacyjnaNowa)
        {
            if(JednostkiOrganizacyjne.Contains(jednostkaOrganizacyjnaStara) && JednostkiOrganizacyjne.Contains(jednostkaOrganizacyjnaNowa))
            {
                var index1 = JednostkiOrganizacyjne.IndexOf(jednostkaOrganizacyjnaStara);
                if(JednostkiOrganizacyjne.ElementAt(index1).Wykladowcy.Contains(wykladowca))
                {
                    JednostkiOrganizacyjne.ElementAt(index1).UsunWykladowce(wykladowca);
                    var index2 = JednostkiOrganizacyjne.IndexOf(jednostkaOrganizacyjnaNowa);
                    JednostkiOrganizacyjne.ElementAt(index2).DodajWyladowce(wykladowca);
                }
                return;
            }
            Console.WriteLine("Blad w danych");
        }

        public bool UsunJednostkeOrganizacyjna(JednostkaOrganizacyjna jednostkaOrganizacyjna)
        {
            if(JednostkiOrganizacyjne.Contains(jednostkaOrganizacyjna))
            {
                JednostkiOrganizacyjne.Remove(jednostkaOrganizacyjna);
                return true;
            }
            return false;
        }

        public bool UsunJednostkeOrganizacyjna(string nazwa, string adres)
        {
            for (int i = 0; i < JednostkiOrganizacyjne.Count; i++)
            {
                if(JednostkiOrganizacyjne[i].Nazwa == nazwa
                    && JednostkiOrganizacyjne[i].Adres == adres)
                {
                    JednostkiOrganizacyjne.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool UsunPrzedmiot(Przedmiot przedmiot)
        {
            if (Przedmioty.Contains(przedmiot))
            {
                Przedmioty.Remove(przedmiot);
                return true;
            }
            return false;
        }

        public bool UsunPrzedmiot(int liczbaGodzin, string nazwa, int semestr, string specjalizacja)
        {
            for (int i = 0; i < Przedmioty.Count; i++)
            {
                if (Przedmioty[i].LiczbaGodzin == liczbaGodzin
                    && Przedmioty[i].Nazwa == nazwa
                    && Przedmioty[i].Semestr == semestr
                    && Przedmioty[i].Specjalizacja == specjalizacja)
                {
                    Przedmioty.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool UsunStudenta(Student student)
        {
            if (Studenci.Contains(student))
            {
                Studenci.Remove(student);
                return true;
            }
            return false;
        }

        public bool UsunStudenta(int numerIndeksu)
        {
            for (int i = 0; i < Studenci.Count; i++)
            {
                if (Studenci[i].NumerIndeksu == numerIndeksu)
                {
                    Studenci.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void ZmienDziekana(Osoba osoba)
        {
            Dziekan = osoba;
        }

        public void WyswietlJednostkiOrganizacyjne()
        {
            Console.WriteLine("Jednostki Organizacyjne");
            foreach (var j in JednostkiOrganizacyjne)
                j.Wyswietlinfo();
        }

        public void WyswietlPrzedmioty()
        {
            Console.WriteLine("Przedmioty");
            foreach (var j in Przedmioty)
                j.Wyswietlinfo();
        }

        public void WyswietlStudentow()
        {
            Console.WriteLine("Studenci");
            foreach (var j in Studenci)
                j.Wyswietlinfo();
        }

        public override string ToString()
        {
            return $"{Nazwa} Dziekan: {Dziekan}";
        }

        public void Wyswietlinfo()
        {
            Console.WriteLine(this);
        }
    }
}
