using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08
{
    [Serializable]
    public class Ocena
    {
        public string Przedmiot { get; set; }
        public double Wartosc { get; set; }

        public Ocena() { }

        public Ocena(string przedmiot, double wartosc)
        {
            Przedmiot = przedmiot;
            Wartosc = wartosc;
        }

        public override string ToString()
        {
            return $"{Przedmiot}: {Wartosc.ToString("0.0")}";
        }
    }
}
