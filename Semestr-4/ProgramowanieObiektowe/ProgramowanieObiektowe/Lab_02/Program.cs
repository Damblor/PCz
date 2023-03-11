using System;

namespace Lab_02
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("====================Osoby====================");

            Osoba o = new("Adam", "Miś", "20.03.1980");
            o.WypiszInfo();

            Console.WriteLine("====================Studenci====================");

            Osoba s1 = new Student("Michał", "Kot", "13.04.1990", 2, 1, 12345);
            Student s2 = new("Krzysztof", "Jeż", "22.12.1990", 2, 5, 54321);

            s1.WypiszInfo();
            s2.WypiszInfo();
            Console.WriteLine("========================================");

            ((Student)s1).DodajOcene("Bazy danych", "01.05.2011", 4.0);

            s2.DodajOcene("Bazy danych", "01.05.2011", 5.0);
            s2.DodajOcene("AWWW", "11.05.2011", 5.0);
            s2.DodajOcene("AWWW", "02.04.2011", 4.5);

            s2.WypiszInfo();
            Console.WriteLine("========================================");

            s2.UsunOcene("AWWW", "02.04.2011", 4.5);

            s2.WypiszInfo();
            Console.WriteLine("========================================");

            s2.DodajOcene("AWWW", "02.04.2011", 4.5);
            s2.UsunOceny("AWWW");

            s2.WypiszInfo();
            Console.WriteLine("========================================");

            s2.DodajOcene("AWWW", "02.04.2011", 4.5);
            s2.UsunOceny();

            s1.WypiszInfo();
            s2.WypiszInfo();

            Console.WriteLine("====================Pilkarze====================");

            Osoba p1 = new Pilkarz("Piotr", "Kos", "14.09.1984", "napastnik", "FC Politechnika");
            Pilkarz p2 = new PilkarzNozny("Adam", "Kołs", "23.07.1999", "obronca", "FC Politechnika");
            PilkarzReczny p3 = new("Maciej", "Kamyk", "11.01.2000", "bramkarz", "FC Politechnika");

            p1.WypiszInfo();
            p2.WypiszInfo();
            p3.WypiszInfo();

            Console.WriteLine("========================================");
            ((Pilkarz)p1).StrzelGola();
            p2.StrzelGola();
            p3.StrzelGola();

            p3.StrzelGola();
            ((Pilkarz)p1).StrzelGola();
            Console.WriteLine("========================================");

            p1.WypiszInfo();
            p2.WypiszInfo();
            p3.WypiszInfo();

            Console.ReadKey();
        }
    }
}
