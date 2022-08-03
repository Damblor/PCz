using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Wlasciciel
    {
        public int IdWlasciciela { get; set; }
        public string Imie { get; set; }
        public string Informacja { get; set; }
        public string Nazwisko { get; set; }

        public override string ToString()
        {
            return $"{IdWlasciciela}. {Imie} {Nazwisko} {Informacja}";
        }
    }
}
