using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal abstract class Pozycja
    {
        protected string tytul, wydawnictwo;
        protected int id, rokWydania;

        public string Tytul { get => tytul; set => tytul = value; }
        public string Wydawnictwo { get => wydawnictwo; set => wydawnictwo = value; }
        public int Id { get => id; set => id = value; }
        public int RokWydania { get => rokWydania; set => rokWydania = value; }

        public Pozycja() { }
        public Pozycja(string tytul, int id, string wydawnictwo, int rokWydania)
        {
            this.tytul = tytul;
            this.id = id;
            this.wydawnictwo = wydawnictwo;
            this.rokWydania = rokWydania;
        }

        public abstract void WypiszInfo();
    }
}
