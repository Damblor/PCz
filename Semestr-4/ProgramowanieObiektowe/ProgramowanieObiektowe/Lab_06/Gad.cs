using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public class Gad : Zwierze
    {
        public bool Jadowity { get; set; }
        
        public Gad(string nazwa, string gatunek, string pozywienie, string pochodzenie, bool jadowity)
            : base(nazwa, gatunek, pozywienie, pochodzenie)
        {
            Jadowity = jadowity;
        }

        public override void WypiszInfo()
        {
            Console.WriteLine($"Gad: {Nazwa}, Gatunek: {Gatunek}, Pozywienie: {Pozywienie}, Pochodzenie: {Pochodzenie}, Jadowity: {Jadowity}");
        }
    }
}
