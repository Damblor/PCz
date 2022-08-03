using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    internal class Wykladowca : Osoba, IWyswietlinfo
    {
        public string Stanowisko { get; set; }
        public string TytylStopien { get; set; }

        public Wykladowca() : base()
        {
            Stanowisko = string.Empty;
            TytylStopien = string.Empty;
        }

        public Wykladowca(string imie, string nazwisko, DateTime dataUrodzin, string stopien, string stanowisko) : 
            base(imie, nazwisko, dataUrodzin)
        {
            Stanowisko = stanowisko;
            TytylStopien = stopien;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {TytylStopien} {Stanowisko}";
        }
    }
}
