using System;

namespace Lab_05
{
    internal class Program
    {
        static void Main()
        {
            Wydzial wydzial = new Wydzial("WIMII",new Osoba("ktos","cos",DateTime.Now));

            JednostkaOrganizacyjna jednostkaOrganizacyjna2 = new JednostkaOrganizacyjna();
            JednostkaOrganizacyjna jednostkaOrganizacyjna = new JednostkaOrganizacyjna("adaw","awda");

            Wykladowca wykladowca1 = new Wykladowca("aa","bb",DateTime.Now,"zz","daw");
            Wykladowca wykladowca2 = new Wykladowca("aaa", "bb", DateTime.Now, "zz", "daw");
        
        
            wydzial.DodajJednostkeOrganizacyjna(jednostkaOrganizacyjna);
            wydzial.Wyswietlinfo();
            wydzial.DodajWykladowce(wykladowca2, jednostkaOrganizacyjna);
            wydzial.DodajWykladowce(wykladowca1, jednostkaOrganizacyjna);
            wydzial.DodajWykladowce(wykladowca1, jednostkaOrganizacyjna);
            wydzial.DodajWykladowce(wykladowca1, jednostkaOrganizacyjna2);
        }
    }
}
