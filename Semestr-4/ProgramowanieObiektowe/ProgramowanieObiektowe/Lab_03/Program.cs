using System;

namespace Lab_03
{
    internal class Program
    {
        static void Main()
        {
            Ksiazka p1 = new("O pise ktory jezdil",1,"Operon",2003,80);
            Ksiazka p22 = new("O pise ktory jezdil", 5, "Operon", 2003, 80);
            Ksiazka p23 = new("O pise ktory jezdil", 6, "Operon", 2003, 80);
            Ksiazka p24 = new("O pise ktory jezdil", 6, "Operon", 2003, 80);
            Ksiazka p2 = new("Dzieci z Bulerbyn", 2, "WIS", 2011, 300);
            Ksiazka p3 = new("Akademia pana kleksa", 3, "HERON", 1998, 450);

            Czasopismo p4 = new("CD ACTION", 100, "CD Red", 2014, 11);
            Czasopismo p6 = new("CD ACTION", 100, "CD Red", 2014, 20);
            Czasopismo p5 = new("CD ACTION", 101, "CD Red", 2014, 15);

            Katalog katalog1 = new("Lektury");
            Katalog katalog2 = new("Czasopisma");

            Biblioteka bib = new("Targowa");
            bib.DodajKatalog(katalog1);
            bib.DodajKatalog(katalog2);
            Autor a1 = new("Adam","Mickiewicz","polak");
            Autor a2 = new("Jan", "Kochanowski", "polak");
            Autor a3 = new("Wislawa", "Szymborska", "polak");
            
            p1.DodajAutora(a1);
            p2.DodajAutora(a1);
            p2.DodajAutora(a2);
            p3.DodajAutora(a3);

            bib.DodajPozycje(p1, "Lektury");
            bib.DodajPozycje(p2, "Lektury");
            bib.DodajPozycje(p3, "Lektury");
            bib.DodajPozycje(p4, "Czasopisma");
            bib.DodajPozycje(p5, "Czasopisma");
            bib.DodajPozycje(p6, "Czasopisma");
            bib.DodajPozycje(p22, "Lektury");
            bib.DodajPozycje(p23, "Lektury");
            bib.DodajPozycje(p24, "Lektury");

            Bibliotekarz bib1 = new("Jan", "Kowalski", "28.11.2008",3400);
            Bibliotekarz bib2 = new("Barlomiej", "Kowalski", "13.07.2015", 2700);

            bib.DodajBibliotekarza(bib1);
            bib.DodajBibliotekarza(bib2);
            bib.DodajBibliotekarza(bib1);

            Console.WriteLine("==============================");

            var b1 = bib.ZnajdzPozycjePoId(17);
            if (b1 != null)
                b1.WypiszInfo();
            else
                Console.WriteLine("Brak pozycji");

            var b2 = bib.ZnajdzPozycjePoTytule("Dzieci z Bulerbyn");
            if (b2 != null)
                foreach (var b in b2)
                    b.WypiszInfo();
            else
                Console.WriteLine("Brak pozycji");


            b2 = bib.ZnajdzPozycjePoTytule("O pise ktory jezdil");
            if (b2 != null)
                foreach (var b in b2)
                    b.WypiszInfo();
            else
                Console.WriteLine("Brak pozycji");

            b2 = bib.ZnajdzPozycjePoTytule("Dzieci");
            if (b2 != null)
                foreach (var b in b2)
                    b.WypiszInfo();
            else
                Console.WriteLine("Brak pozycji");

            Console.WriteLine("==============================");
            bib.WypiszBibliotekarzy();
            Console.WriteLine("==============================");
            bib.WypiszWszystkiePozycje();


            /*katalog.DodajPozycje(p1);
            katalog.DodajPozycje(p2);
            katalog.DodajPozycje(p3);
            katalog.DodajPozycje(p4);
            katalog.DodajPozycje(p5);

            katalog.WypiszWszystkiePozycje();
            var z = katalog.ZnajdzPozycje("O pise ktory jezdial", 1, "Operon", 2003);

            Console.WriteLine("====================");
            z.WypiszInfo();*/

            Console.ReadKey();
        }
    }
}
