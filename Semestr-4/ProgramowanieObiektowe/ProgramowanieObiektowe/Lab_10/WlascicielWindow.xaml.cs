using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab_10
{
    /// <summary>
    /// Interaction logic for WlascicielWindow.xaml
    /// </summary>
    public partial class WlascicielWindow : Window
    {
        public Wlasciciel wlasciciel;
        public WlascicielWindow(Wlasciciel? wlasciciel = null)
        {
            InitializeComponent();
            this.wlasciciel = wlasciciel ?? new Wlasciciel();
        }

        private void OK_button_Click(object sender, RoutedEventArgs e)
        {
            wlasciciel.Imie = tbImie.Text;
            wlasciciel.Nazwisko = tbNazwisko.Text;
            wlasciciel.Informacja = tbInformacja.Text;
            this.DialogResult = true;
        }
    }
}
