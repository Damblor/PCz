using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public class Ptak : Zwierze
    {
        public double Wytrzymalosc { get; set; }
        public double RozpietoscSkrzydel { get; set; }

        public Ptak(string nazwa, string gatunek, string pozywienie, string pochodzenie, double wytrzymalosc, double rozpietoscSkrzydel) : base(nazwa, gatunek, pozywienie, pochodzenie)
        {
            Wytrzymalosc = wytrzymalosc;
            RozpietoscSkrzydel = rozpietoscSkrzydel;
        }
        
        public double MaksymalnaDlugoscLotu()
        {
            return Wytrzymalosc * RozpietoscSkrzydel;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine($"Ptak: {Nazwa}, Gatunek: {Gatunek}, Pozywienie: {Pozywienie}, Pochodzenie: {Pochodzenie}, Wytrzymalosc: {Wytrzymalosc}, Rozpietosc skrzydel: {RozpietoscSkrzydel}, Maksymalna dlugosc lotu: {MaksymalnaDlugoscLotu()}");
        }
    }
}
