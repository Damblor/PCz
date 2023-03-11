using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    internal class Samochod
    {
        string marka, model, numerRejestracyjny;
        int liczbaDrzwi, pojemnoscSilnika;
        double srednieSpalanie;
        static int liczbaSamochodow = 0;

        public string Marka
        {
            get => marka; 
            set => marka = value; 
        }
        public string Model
        {
            get => model;
            set => model = value;
        }
        public string NumerRejestracyjny
        {
            get => numerRejestracyjny;
            set => numerRejestracyjny = value;
        }
        public int LiczbaDrzwi
        {
            get => liczbaDrzwi;
            set => liczbaDrzwi = value;
        }
        public int PojemnoscSilnika
        {
            get => pojemnoscSilnika;
            set => pojemnoscSilnika = value;
        }
        public double SrednieSpalanie
        {
            get => srednieSpalanie;
            set => srednieSpalanie = value;
        }

        public Samochod() 
        {
            marka = "nieznana";
            model = "nieznany";
            numerRejestracyjny = "nieznany";
            liczbaDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0.0;
            liczbaSamochodow++;
        }
        public Samochod(string marka,
            string model,
            int liczbaDrzwi,
            int pojemnoscSilnika,
            double srednieSpalanie,
            string numerRejestracyjny)
        {
            this.marka = marka;
            this.model = model;
            this.liczbaDrzwi = liczbaDrzwi;
            this.pojemnoscSilnika = pojemnoscSilnika;
            this.srednieSpalanie = srednieSpalanie;
            this.numerRejestracyjny = numerRejestracyjny;
            liczbaSamochodow++;
        }
        ~Samochod()
        {
            liczbaSamochodow--;
        }

        private double ObliczSpalanie(double dlugoscTrasy)
        {
            return (srednieSpalanie * dlugoscTrasy)/100.0;
        }
        public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
        {
            return ObliczSpalanie(dlugoscTrasy) * cenaPaliwa;
        }
        public void WypiszInfo()
        {
            Console.WriteLine(this.GetType().Name);
            Console.WriteLine($"\tMarka: {marka}");
            Console.WriteLine($"\tModel: {model}");
            Console.WriteLine($"\tLiczba drzwi: {liczbaDrzwi}");
            Console.WriteLine($"\tPojemnosc silnika: {pojemnoscSilnika}");
            Console.WriteLine($"\tSrednie spalanie: {srednieSpalanie}");
        }
        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine($"Ilosc samochodow: {liczbaSamochodow}");
        }
    }
}
