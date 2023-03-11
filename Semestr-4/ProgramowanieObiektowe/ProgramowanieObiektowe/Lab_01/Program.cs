using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    class Program
    {
        /*static void Main(string[] args)
        {
            *//*Samochod s1 = new Samochod();
            s1.WypiszInfo();
            s1.Marka = "Fiat";
            s1.Model = "126p";
            s1.LiczbaDrzwi = 2;
            s1.PojemnoscSilnika = 650;
            s1.SrednieSpalanie = 6.0;

            s1.WypiszInfo();
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
            s2.WypiszInfo();
            double kosztPrzejazdu = s2.ObliczKosztPrzejazdu(30.5, 4.85);
            Console.WriteLine($"Koszt przejazdu: {kosztPrzejazdu}");
            Samochod.WypiszIloscSamochodow();*/

        /*Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0);
        Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);

        Garaz g1 = new Garaz();
        g1.Adres = "ul. Garazowa 1";
        g1.Pojemnosc = 1;

        Garaz g2 = new Garaz("ul. Garazowa 2", 2);

        g1.WprowadzSamochod(s1);
        g1.WypiszInfo();
        g1.WprowadzSamochod(s2);

        g2.WprowadzSamochod(s1);
        g2.WprowadzSamochod(s2);
        g2.WypiszInfo();

        g2.WyprowadzSamochod();
        g2.WypiszInfo();

        g2.WyprowadzSamochod();
        g2.WyprowadzSamochod();*/

        /*Osoba o1 = new Osoba();
        Osoba o2 = new Osoba("JJ", "Kowalski", "ul. Akacjowa", 2);

        o1.DodajSamochod("SC 20123");

        o2.DodajSamochod("SC 20123");
        o2.DodajSamochod("SC 12345");
        o2.DodajSamochod("SC 22133");

        o2.UsunSamochod("SC 20123");
        o2.UsunSamochod("SC 22133");
        o1.WypiszInfo();
        o2.WypiszInfo();*//*


        Console.ReadKey();
        }*/
        static void Main(string[] args)
        {
            /*Zad1 zad = new Zad1();
            zad.Run();*/

            Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0, "SC 451");
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6,"SC 1234");

            Garaz g1 = new Garaz();
            g1.Adres = "ul. Garazowa 1";
            g1.Pojemnosc = 1;

            Garaz g2 = new Garaz("ul. Garazowa 2", 2);

            g1.WprowadzSamochod(s1);
            g1.WypiszInfo();
            g1.WprowadzSamochod(s2);

            g2.WprowadzSamochod(s1);
            g2.WprowadzSamochod(s2);
            g2.WypiszInfo();

            g2.WyprowadzSamochod();
            g2.WypiszInfo();

            g2.WyprowadzSamochod();
            g2.WyprowadzSamochod();

            Console.ReadKey();
        }
    }
}
