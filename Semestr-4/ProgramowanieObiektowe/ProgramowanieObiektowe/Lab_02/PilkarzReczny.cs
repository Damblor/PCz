using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class PilkarzReczny : Pilkarz
    {
        public PilkarzReczny() : base() { }
        public PilkarzReczny(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub) : 
            base(imie, nazwisko, dataUrodzenia, pozycja, klub) { }

        public override void StrzelGola()
        {
            base.StrzelGola();
            Console.WriteLine("Reczny Strzelil!");
        }
    }
}
