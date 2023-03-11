using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BazaDanych bazaDanych = new BazaDanych();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemWlascicieleWyswietlWszystkich_Click(object sender, RoutedEventArgs e)
        {
            bazaDanych.SP_Wlasciciele_Select(dataGrid.Items, dataGrid.Columns);
        }

        private void MenuItemWyjscie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemSamochodyDodajNowy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSamochodyUsun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemSamochdyWyswietlWszystkie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemWlascicieleDodajNowy_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new WlascicielWindow();

            if(dialog.ShowDialog() == true)
            {
                int liczbaWierszy = bazaDanych.SP_Wlasciciele_Insert(dialog.wlasciciel);
                MessageBox.Show($"Wstawiono {liczbaWierszy} wierszy");
                bazaDanych.SP_Wlasciciele_Select(dataGrid.Items, dataGrid.Columns);
            }
        }

        private void MenuItemWlascicieleUsun_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem is Wlasciciel)
            {
                int liczbaWierszy = bazaDanych.SP_Wlasciciele_Delete(dataGrid.SelectedItem as Wlasciciel);
                MessageBox.Show($"Usunieto {liczbaWierszy} wierszy");
                bazaDanych.SP_Wlasciciele_Select(dataGrid.Items, dataGrid.Columns);
            }
            else
            {
                MessageBox.Show("Wskaz wlasciciela do usuniecia");
            }
        }

        private void MenuItemWlascicielePosiadanePojazdy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
