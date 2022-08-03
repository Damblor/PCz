using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_08
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student student;
        public StudentWindow(Student? student = null)
        {
            InitializeComponent();

            if(student != null)
            {
                tbImie.Text = student.Imie;
                tbNazwisko.Text = student.Nazwisko;
                tbNrIndeksu.Text = student.NrIndeksu.ToString();
                tbWydzial.Text = student.Wydzial;
            }
            this.student = student ?? new Student();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!Regex.IsMatch(tbImie.Text,@"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbNazwisko.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbWydzial.Text, @"^\p{Lu}{1,12}$") ||
                !Regex.IsMatch(tbNrIndeksu.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Nie poprawne dane");
                return;
            }
            student.Imie = tbImie.Text;
            student.Nazwisko = tbNazwisko.Text;
            student.NrIndeksu = int.Parse(tbNrIndeksu.Text);
            student.Wydzial = tbWydzial.Text;
            this.DialogResult = true;
        }
    }
}
