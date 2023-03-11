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
    /// Interaction logic for ModifyStudent.xaml
    /// </summary>
    public partial class ModifyStudent : Window
    {
        public Student student;
        public ModifyStudent(Student student)
        {
            InitializeComponent();
            this.student = student;
            tbImie.Text = student.Imie;
            tbNazwisko.Text = student.Nazwisko;
            tbNrIndeksu.Text = student.NrIndeksu.ToString();
            tbWydzial.Text = student.Wydzial;

            og.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Przedmiot") });
            og.Columns.Add(new DataGridTextColumn() { Header = "Wartosc", Binding = new Binding("Wartosc") });
            og.AutoGenerateColumns = false;
            og.ItemsSource = student.oceny;
        }

        private void Modify_mark_Click(object sender, RoutedEventArgs e)
        {
            if (og.SelectedItem is not Ocena)
            {
                MessageBox.Show("Wybierz ocenę");
                return;
            }
            Ocena ocena = (Ocena)og.SelectedItem;
            var dialog = new MarkWindow(ocena);
            if (dialog.ShowDialog() == true)
            {
                var n = student.oceny.IndexOf(ocena);
                student.oceny[n] = dialog.ocena;
                og.Items.Refresh();
            }
        }


        private void Add_mark_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MarkWindow();
            if (dialog.ShowDialog() == true)
            {
                student.oceny.Add(dialog.ocena);
                og.Items.Refresh();
            }
        }

        private void OK_button_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbImie.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbNazwisko.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(tbWydzial.Text, @"^\p{Lu}{1,12}$") ||
                !Regex.IsMatch(tbNrIndeksu.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Błędne dane");
                return;
            }
            student.Imie = tbImie.Text;
            student.Nazwisko = tbNazwisko.Text;
            student.NrIndeksu = int.Parse(tbNrIndeksu.Text);
            student.Wydzial = tbWydzial.Text;
            this.DialogResult = true;
        }

        private void Remove_mark_Click(object sender, RoutedEventArgs e)
        {
            if (og.SelectedItem is Ocena)
                student.oceny.Remove((Ocena)og.SelectedItem);
            og.Items.Refresh();
        }
    }
}
