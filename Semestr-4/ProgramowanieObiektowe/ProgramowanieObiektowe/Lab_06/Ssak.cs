using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public class Ssak : Zwierze
    {
        public string Srodowisko { get; set; }

        public Ssak(string nazwa, string gatunek, string pozywienie, string pochodzenie, string srodowisko) : base(nazwa, gatunek, pozywienie, pochodzenie)
        {
            Srodowisko = srodowisko;
        }
        public override void WypiszInfo()
        {
            Console.WriteLine($"{Nazwa} jest ssakiem, pochodzenie: {Pochodzenie}, pozywienie: {Pozywienie}, gatunek: {Gatunek}, srodowisko: {Srodowisko}");
        }
    }
}
