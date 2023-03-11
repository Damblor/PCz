using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08
{
    [Serializable]
    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int NrIndeksu { get; set; }
        public string Wydzial { get; set; }

        public string Oceny { get { return GetMarks(); } }

        public ObservableCollection<Ocena> oceny = new ObservableCollection<Ocena>();

        public Student() { }
        public Student(string imie, string nazwisko, int nrindeksu, string wydzial)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            NrIndeksu = nrindeksu;
            Wydzial = wydzial;
        }

        private string GetMarks()
        {
            StringBuilder sb = new StringBuilder();

            if (oceny.Count > 0)
            {
                foreach (var o in oceny)
                {
                    sb.Append($"{o} ");
                }
            }
            else
            {
                sb.Append("Brak Ocen");
            }
            return sb.ToString();
        }
    }
}
