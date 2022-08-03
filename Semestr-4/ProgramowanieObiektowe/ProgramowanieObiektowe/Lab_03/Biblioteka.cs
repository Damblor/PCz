using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal class Biblioteka : IZarzadzaniePozycjami
    {
        private string adres;
        private readonly List<Bibliotekarz> bibliotekarze = new();
        private readonly List<Katalog> katalogi = new();

        public string Adres { get => adres; set => adres = value; }

        public Biblioteka()
        {
            adres = "nieznany";
        }
        public Biblioteka(string adres)
        {
            this.adres = adres;
        }

        public void DodajBibliotekarza(Bibliotekarz bib)
        {
            if (bibliotekarze.Contains(bib))
            {
                Console.WriteLine("Bibliotekarz juz jest dodany");
                return;
            }
            bibliotekarze.Add(bib);
        }

        public void WypiszBibliotekarzy()
        {
            foreach (var b in bibliotekarze)
                b.WypiszInfo();
        }

        public void DodajKatalog(Katalog kat)
        {
            if (katalogi.Contains(kat))
            {
                Console.WriteLine("Katalog juz jest dodany");
                return;
            }
            katalogi.Add(kat);
        }

        public void DodajPozycje(Pozycja poz, string dzialTematyczny)
        {
            for(int i = 0; i < katalogi.Count; i++)
            {
                if(katalogi[i].DzialTematyczny == dzialTematyczny)
                {
                    katalogi[i].DodajPozycje(poz);
                    return;
                }
            }
            Console.WriteLine("Nie ma takiego dzialu");
        }

        public List<Pozycja> ZnajdzPozycjePoTytule(string tytul)
        {
            var pozycje = new List<Pozycja>();
            foreach(var k in katalogi)
            {
                var poz = k.ZnajdzPozycjePoTytule(tytul);
                if(poz != null)
                {
                    foreach (var p in poz)
                        pozycje.Add(p);
                }
            }
            return pozycje.Count > 0 ? pozycje : null;
        }

        public Pozycja ZnajdzPozycjePoId(int id)
        {
            Pozycja p = null;
            foreach (var k in katalogi)
                p = k.ZnajdzPozycjePoId(id);
            return p;
        }

        public void WypiszWszystkiePozycje()
        {
            foreach (var k in katalogi)
                k.WypiszWszystkiePozycje();
        }
    }
}
