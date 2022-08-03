using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    internal interface IZarzadzaniePozycjami
    {
        public abstract List<Pozycja> ZnajdzPozycjePoTytule(string tytul);

        public abstract Pozycja ZnajdzPozycjePoId(int id);

        public abstract void WypiszWszystkiePozycje();
    }
}
