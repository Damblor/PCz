using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06
{
    public class Klatka
    {
        public uint Id { get; set; }
        public uint Rozmiar { get; set; }

        private readonly List<Zwierze> zwierzeta = new();

        public Klatka(uint id, uint rozmiar)
        {
            Id = id;
            Rozmiar = rozmiar;
        }
        public void DodajZwierze(Zwierze zwierze)
        {
            zwierzeta.Add(zwierze);
        }
        public void UsunZwierze(Zwierze zwierze)
        {
            zwierzeta.Remove(zwierze);
        }
    }

    public class GetId
    {
        public static uint ID = 0;
        
        public static uint GetNewId()
        {
            return ID++;
        }
    }
}
