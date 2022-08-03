using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class Pilkarz : Osoba
    {
        private string pozycja, klub;
        private int liczbaGoli = 0;

        public string Pozycja { get => pozycja; set => pozycja = value; }
        public string Klub { get => klub; set => klub = value; }
        public int LiczbaGoli { get => liczbaGoli; set => liczbaGoli = value; }

        public Pilkarz() : base()
        {
            pozycja = "nieznana";
            klub = "nieznany";
        }
        public Pilkarz(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub) : 
            base(imie, nazwisko, dataUrodzenia)
        {
            this.pozycja = pozycja;
            this.klub = klub;
        }

        public override void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine($"\tPozycja: {pozycja}\n\tKlub: {klub}\n\tLiczba goli: {liczbaGoli}");
        }
        public virtual void StrzelGola()
        {
            liczbaGoli++;
        }
    }
}
