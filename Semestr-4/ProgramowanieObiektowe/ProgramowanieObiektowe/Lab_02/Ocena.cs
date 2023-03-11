using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class Ocena
    {
        private string nazwaPrzedmiotu, data;
        private double wartosc;

        public string NazwaPrzedmiotu { get => nazwaPrzedmiotu; set => nazwaPrzedmiotu = value; }
        public string Data { get => data; set => data = value; }
        public double Wartosc { get => wartosc; set => wartosc = value; }

        public Ocena() { }
        public Ocena(string nazwaPrzedmiotu, string data, double wartosc)
        {
            this.nazwaPrzedmiotu = nazwaPrzedmiotu;
            this.data = data;
            this.wartosc = wartosc;
        }

        public void WypiszInfo()
        {
            Console.WriteLine($"\t\tNazwa Przedmiotu: {nazwaPrzedmiotu}\n\t\tData: {data}\n\t\tWartosc: {wartosc}");
        }
    }
}
