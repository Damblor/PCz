using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Lab_10
{
    internal class BazaDanych
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dambi\Desktop\PCZ\ProgramowanieObiektowe\Lab_10\BazaDanych.mdf;Integrated Security=True";

        //public int SP_Samochody_delete(Samochod s)
        //{

        //}

        public void SP_Wlasciciele_Select(
            ItemCollection ic,
            ObservableCollection<DataGridColumn> c = null)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string command = "SP_Wlasciciele_select";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(c!= null)
                {
                    c.Clear();
                    c.Add(new DataGridTextColumn()
                    {
                        Header = reader.GetName(0),
                        Binding = new Binding("IdWlasciciela"),
                        Visibility = System.Windows.Visibility.Hidden
                    });
                    c.Add(new DataGridTextColumn()
                    {
                        Header = reader.GetName(1),
                        Binding = new Binding("Nazwisko")
                    });
                    c.Add(new DataGridTextColumn()
                    {
                        Header = reader.GetName(2),
                        Binding = new Binding("Imie")
                    });

                    ic.Clear();
                    while(reader.Read())
                    {
                        ic.Add(new Wlasciciel
                        {
                            IdWlasciciela = (int)reader[0],
                            Nazwisko = (string)reader[1],
                            Imie = (string)reader[2],
                        });
                    }
                }
            }
        }

        public int SP_Wlasciciele_Insert(Wlasciciel wlasciciel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string command = "SP_Wlasciciele_insert";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nazwisko", wlasciciel.Nazwisko);
                    cmd.Parameters.AddWithValue("@Imie", wlasciciel.Imie);

                    connection.Open();
                    int liczbaWierszy = cmd.ExecuteNonQuery();

                    return liczbaWierszy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int SP_Wlasciciele_Delete(Wlasciciel wlasciciel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string command = "SP_Wlasciciele_delete";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nazwisko", wlasciciel.Nazwisko);
                    cmd.Parameters.AddWithValue("@Imie", wlasciciel.Imie);

                    connection.Open();
                    int liczbaWierszy = cmd.ExecuteNonQuery();

                    return liczbaWierszy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int SP_Liczba_Posiadanych_Pojazdów(Wlasciciel wlasciciel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string command = "SP_Samochody_select_liczba_samochodow";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nazwisko", wlasciciel.Nazwisko);
                    cmd.Parameters.AddWithValue("@Imie", wlasciciel.Imie);

                    connection.Open();
                    int liczbaWierszy = cmd.ExecuteNonQuery();

                    return liczbaWierszy;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
