using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal class Katalog : IZarzadzaniePozycjami
    {
        private string dzialTematyczny;

        private readonly List<Pozycja> pozycje = new();
        
        public string DzialTematyczny { get => dzialTematyczny; set => dzialTematyczny = value;}

        public Katalog() { dzialTematyczny = "brak"; }
        public Katalog(string dzial) { this.dzialTematyczny = dzial; }

        public void DodajPozycje(Pozycja pozycja)
        {
            if(pozycje.Contains(pozycja))
            {
                Console.WriteLine("Pozycja jest juz dodana");
                return;
            }
            if(pozycje.FindIndex(x => x.Id == pozycja.Id) >= 0)
            {
                Console.WriteLine("Pozycja o podanym id juz istnieje");
                return;
            }
            pozycje.Add(pozycja);
        }

        public Pozycja ZnajdzPozycje(string tytul, int id, string wydawnictwo, int rokWydania)
        {
            int index = pozycje.FindIndex(x => x.Tytul == tytul &&
            x.Id == id && x.RokWydania == rokWydania &&
            x.Wydawnictwo == wydawnictwo);
            return index == -1 ? null : pozycje[index];
        }

        public void WypiszWszystkiePozycje()
        {
            foreach (var p in pozycje)
                p.WypiszInfo();
        }

        public List<Pozycja> ZnajdzPozycjePoTytule(string tytul)
        {
            var p = pozycje.FindAll(x => x.Tytul.Equals(tytul));
            return p.Count == 0 ? null : p;
        }

        public Pozycja ZnajdzPozycjePoId(int id)
        {
            int index = pozycje.FindIndex(x => x.Id == id);
            return index == -1 ? null : pozycje[index];
        }
    }
}
