using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    internal class OcenaKoncowa : IWyswietlinfo
    {
        public DateTime Data { get; set; }
        public Przedmiot Przedmiot { get; set; }
        public double Wartosc { get; set; }

        public OcenaKoncowa(Przedmiot przedmiot, double wartosc, DateTime data)
        {
            Przedmiot = przedmiot;
            Wartosc = wartosc;
            Data = data;
        }
        public override string ToString()
        {
            return $"Przedmiot: {Przedmiot} Ocena {Wartosc} Data {Data}";
        }
        public void Wyswietlinfo()
        {
            Console.WriteLine(this);
        }
    }
}
