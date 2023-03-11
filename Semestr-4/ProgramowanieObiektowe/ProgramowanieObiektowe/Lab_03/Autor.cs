using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal class Autor : Osoba
    {
        private string narodowosc;

        public string Narodowosc { get => narodowosc; set => narodowosc = value; }

        public Autor() : base()
        {
            narodowosc = "nieznana";
        }
        public Autor(string imie, string nazwisko, string narodowosc) :
            base(imie, nazwisko)
        {
            this.narodowosc = narodowosc;
        }

        public override void WypiszInfo()
        {
            Console.Write('\t');
            base.WypiszInfo();
            Console.WriteLine($"\t\t\tNarodowosc: {narodowosc}");
        }
    }
}
