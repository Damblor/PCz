using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    internal class JednostkaOrganizacyjna : IWyswietlinfo
    {
        public string Adres { get; set; }
        public string Nazwa { get; set; }
        public IList<Wykladowca> Wykladowcy { get; set; }

        public JednostkaOrganizacyjna()
        {
            Adres = string.Empty;
            Nazwa = string.Empty;
            Wykladowcy = new List<Wykladowca>();
        }
        public JednostkaOrganizacyjna(string nazwa, string adres, IList<Wykladowca> wykladowcy = null)
        {
            Adres = adres;
            Nazwa = nazwa;
            if(wykladowcy != null)
                Wykladowcy = wykladowcy;
            else
                Wykladowcy = new List<Wykladowca>();
        }

        public void DodajWyladowce(Wykladowca wykladowca)
        {
            if(Wykladowcy.Contains(wykladowca))
            {
                Console.WriteLine("Wykladowca jest juz dodany");
                return;
            }
            Wykladowcy.Add(wykladowca);
        }
        public bool UsunWykladowce(string imie, string nazwisko)
        {
            for(int i = 0; i < Wykladowcy.Count; i++)
            {
                if (Wykladowcy[i].Imie.Equals(imie) && Wykladowcy[i].Nazwisko.Equals(nazwisko))
                {
                    Wykladowcy.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool UsunWykladowce(Wykladowca wykladowca)
        {
            if (!Wykladowcy.Contains(wykladowca))
            {
                Console.WriteLine("Wykladowca nie istnieje");
                return false;
            }
            Wykladowcy.Remove(wykladowca);
            return true;
        }

        public override string ToString()
        {
            return $"Nazwa: {Nazwa} Adres: {Adres}";
        }

        public string ToString(bool zWykladowcami = false)
        {
            return $"Nazwa: {Nazwa} Adres: {Adres}";
        }

        public void Wyswietlinfo()
        {
            Console.WriteLine(this);
        }

        public void WyswietlWykladowcow()
        {
            foreach(var wykladowca in Wykladowcy)
                wykladowca.Wyswietlinfo();
        }
    }
}
