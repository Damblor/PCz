using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal class Ksiazka : Pozycja
    {
        private int liczbaStron;
        private readonly List<Autor> autorzy = new();

        public int LiczbaStron { get => liczbaStron; set => liczbaStron = value; }

        public Ksiazka() : base()
        {
            liczbaStron = 0;
        }
        public Ksiazka(string tytul,
            int id,
            string wydawnictwo,
            int rokWydania,
            int liczbaStron) :
            base(tytul, id, wydawnictwo,rokWydania)
        {
            this.liczbaStron = liczbaStron;
        }

        public void DodajAutora(Autor autor)
        {
            if(autorzy.Contains(autor))
            {
                Console.WriteLine("Autor juz jest dodany");
                return;
            }
            autorzy.Add(autor);
        }

        public override void WypiszInfo()
        {
            Console.WriteLine($"{this.GetType().Name}\n" +
                $"\tTytul: {tytul}\n" +
                $"\tID: {id}\n" +
                $"\tWydawnictwo: {wydawnictwo}\n" +
                $"\tRok Wydania: {rokWydania}\n" +
                $"\tLiczba stron: {liczbaStron}\n" +
                $"\tAutorzy:");
            foreach(var a in autorzy)
                a.WypiszInfo();
        }
    }
}
