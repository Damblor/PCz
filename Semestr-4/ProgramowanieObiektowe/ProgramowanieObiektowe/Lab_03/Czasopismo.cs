using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal class Czasopismo : Pozycja
    {
        private int numer;

        public int Numer { get => numer; set => numer = value; }

        public Czasopismo() : base()
        {
            numer = 0;
        }
        public Czasopismo(string tytul,
            int id,
            string wydawnictwo,
            int rokWydania,
            int numer) :
            base(tytul, id, wydawnictwo,rokWydania)
        {
            this.numer = numer;
        }

        public override void WypiszInfo()
        {
            Console.WriteLine($"{this.GetType().Name}\n" +
                $"\tTytul: {tytul}\n" +
                $"\tID: {id}\n" +
                $"\tWydawnictwo: {wydawnictwo}\n" +
                $"\tRok Wydania: {rokWydania}\n" +
                $"\tNumer: {numer}");
        }
    }
}
