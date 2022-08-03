using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public abstract class Zwierze
    {
        public string Nazwa { get; set; }
        public string Gatunek { get; set; }
        public string Pozywienie { get; set; }
        public string Pochodzenie { get; set; }
        
        public Zwierze(string nazwa, string gatunek, string rodzajPozywienia, string pochodzenie)
        {
            Nazwa = nazwa;
            Gatunek = gatunek;
            Pozywienie = rodzajPozywienia;
            Pochodzenie = pochodzenie;
        }

        public abstract void WypiszInfo();
    }
}
