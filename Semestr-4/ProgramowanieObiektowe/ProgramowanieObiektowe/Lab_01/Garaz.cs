using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal class Garaz
    {
        private string adres;
        private int pojemnosc, liczbaSamochodow = 0;

        private Samochod[] samochody;

        public string Adres
        {
            get => adres;
            set => adres = value;
        }
        public int Pojemnosc
        {
            get => pojemnosc;
            set
            {
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }
        public int LiczbaSamochodow
        {
            get => liczbaSamochodow;
            set => liczbaSamochodow = value;
        }

        public Garaz()
        {
            adres = "nieznany";
            pojemnosc = 0;
            samochody = null;
        }
        public Garaz(string adres, int pojemnosc)
        {
            this.adres = adres;
            this.pojemnosc = pojemnosc;
            samochody = new Samochod[pojemnosc];
        }

        public void WprowadzSamochod(Samochod sam)
        {
            if(liczbaSamochodow >= pojemnosc)
            {
                Console.WriteLine("Garaz jest zapelniony");
                return;
            }
            samochody[liczbaSamochodow] = sam;
            liczbaSamochodow++;
        }

        public Samochod WyprowadzSamochod()
        {
            if (liczbaSamochodow <= 0)
            {
                Console.WriteLine("Garaz jest pusty");
                return null;
            }
            liczbaSamochodow--;
            Samochod sam = samochody[liczbaSamochodow];
            samochody[liczbaSamochodow] = null;
            return sam;
        }

        public void WypiszInfo()
        {
            Console.WriteLine(this.GetType().Name);
            Console.WriteLine($"\tAdres: {adres}");
            Console.WriteLine($"\tPojemnosc: {liczbaSamochodow}/{pojemnosc}");
            for (int i = 0; i < liczbaSamochodow; i++)
            {
                samochody[i].WypiszInfo();
            }
        }
    }
}
