using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal class Bibliotekarz : Osoba
    {
        private string dataZatrudnienia;
        private double wynagrodzenie;

        public string DataZatrudnienia { get => dataZatrudnienia; set => dataZatrudnienia = value;}
        public double Wynagrodzenie { get => wynagrodzenie; set => wynagrodzenie = value; }

        public Bibliotekarz() : base()
        {
            dataZatrudnienia = "nieznana";
            wynagrodzenie = 0;
        }

        public Bibliotekarz(string imie, string nazwisko, string dataZatrudnienia, double wynagrodzenia) :
            base(imie,nazwisko)
        {
            this.dataZatrudnienia = dataZatrudnienia;
            this.wynagrodzenie = wynagrodzenia;
        }

        public override void WypiszInfo()
        {
            Console.WriteLine(this.GetType().Name);
            base.WypiszInfo();
            Console.WriteLine($"\t\tData zatrudnienia: {dataZatrudnienia}\n\t\tWynagrodzenia: {wynagrodzenie}");
        }
    }
}
