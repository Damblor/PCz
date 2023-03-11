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
    /// Interaction logic for MarkWindow.xaml
    /// </summary>
    public partial class MarkWindow : Window
    {

        public Ocena ocena;
        public MarkWindow(Ocena? ocena = null)
        {
            InitializeComponent();
            this.ocena = ocena ?? new Ocena();
            if(ocena != null)
            {
                tbOcena.Text = ocena.Wartosc.ToString("0.0");
                tbPrzedmiot.Text = ocena.Przedmiot;
            }
        }

        private void B_add_mark_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbOcena.Text, @"^(1|2|3|4|5)(\.|\,)(0|5)$") ||
                !Regex.IsMatch(tbPrzedmiot.Text, @"^\p{Lu}{1,12}$"))
            {
                MessageBox.Show("Nie poprawne dane");
                return;
            }
            ocena.Przedmiot = tbPrzedmiot.Text;
            ocena.Wartosc = double.Parse(tbOcena.Text.Replace('.', ','));
            this.DialogResult = true;
        }
    }
}
