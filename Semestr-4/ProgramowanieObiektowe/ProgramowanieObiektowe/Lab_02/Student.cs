using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    internal class Student : Osoba
    {
        private int rok, grupa, nrIndeksu;

        private readonly List<Ocena> oceny = new();

        public int Rok {  get => rok; set => rok = value; }
        public int Gropa { get => grupa; set => grupa = value; }
        public int NrIndeksu { get => nrIndeksu; set => nrIndeksu = value; }

        public Student() : base()
        {
            rok = 0;
            grupa = 0;
            nrIndeksu = 0;
        }

        public Student(string imie, string nazwisko, string dataUrodzenia,int rok, int grupa, int nrIndeksu) : 
            base(imie, nazwisko, dataUrodzenia)
        {
            this.rok = rok;
            this.grupa = grupa;
            this.nrIndeksu = nrIndeksu;
        }

        public void DodajOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            oceny.Add(new Ocena(nazwaPrzedmiotu, data, wartosc));
        }

        public void UsunOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            /*oceny.RemoveAll(o => o.NazwaPrzedmiotu.Equals(nazwaPrzedmiotu) 
            && o.Data.Equals(data) 
            && o.Wartosc == wartosc);*/

            for(int i = 0; i < oceny.Count; i++)
            {
                if(oceny[i].NazwaPrzedmiotu.Equals(nazwaPrzedmiotu)
                    && oceny[i].Data == data
                    && oceny[i].Wartosc == wartosc)
                {
                    oceny.RemoveAt(i);
                    break;
                }
            }
        }

        public void UsunOceny(string nazwaPrzedmiotu)
        {
            //oceny.RemoveAll(o => o.NazwaPrzedmiotu.Equals(nazwaPrzedmiotu));
            for (int i = oceny.Count - 1; i > 0; i--)
            {
                if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu)
                {
                    oceny.RemoveAt(i);
                }
            }
        }

        public void UsunOceny()
        {
            oceny.Clear();
        }

        public void WypiszOceny(string nazwaPrzedmiotu)
        {
            for (int i = 0; i < oceny.Count; i++)
            {
                if (oceny[i].NazwaPrzedmiotu.Equals(nazwaPrzedmiotu))
                {
                    oceny[i].WypiszInfo();
                }
            }
        }

        public void WypiszOceny()
        {
            foreach (Ocena o in oceny)
                o.WypiszInfo();
        }

        public override void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine($"\tRok: {rok}\n\tGrupa: {grupa}\n\tNrIndeksu: {nrIndeksu}\n\tLiczba ocen: {oceny.Count}");
            foreach (Ocena o in oceny)
                o.WypiszInfo();
        }
    }
}
