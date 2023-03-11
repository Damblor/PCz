using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml.Serialization;

namespace Lab_08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> list { get; set; }

        public MainWindow()
        {
            list = new ObservableCollection<Student>()
            {
                new Student("Jan","Kowalski",1033,"WIMII"),
                new Student("Michał","Nowak",1013,"WIMII"),
                new Student("Jacek","Makieta",1021,"WIMII")
            };
            list[0].oceny.Add(new Ocena("WWW", 5.0));

            InitializeComponent();

            dg.Columns.Add(new DataGridTextColumn() { Header = "Imie", Binding = new Binding("Imie") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Nazwisko") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "NrIndeksu", Binding = new Binding("NrIndeksu") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Wydzial", Binding = new Binding("Wydzial") });
            dg.Columns.Add(new DataGridTextColumn() { Header = "Oceny", Binding = new Binding("Oceny") });
            dg.AutoGenerateColumns = false;
            dg.ItemsSource = list;
        }

        private void B_add_student_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if(dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                dg.Items.Refresh();
            }
        }

        private void B_remove_student_Click(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem is Student)
                list.Remove((Student)dg.SelectedItem);
            dg.Items.Refresh();
        }

        private void Modify_Student_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItem is not Student)
            {
                MessageBox.Show("Wybierz studenta");
                return;
            }
            Student student = (Student)dg.SelectedItem;
            var dialog = new ModifyStudent(student);
            if (dialog.ShowDialog() == true)
            {
                var n = list.IndexOf(student);
                list[n] = dialog.student;
                dg.Items.Refresh();
            }
        }

        private void Save_Data_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Txt Files (*.txt)|*.txt|XML Files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                var extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                switch(extension)
                {
                    case ".txt":
                        SaveTxt(saveFileDialog.FileName);
                        break;
                    case ".xml":
                        SaveXml(saveFileDialog.FileName);
                        break;
                    default:
                        MessageBox.Show("Złe rozszerzenie");
                        break;
                }
            }
        }

        private void Load_Data_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt Files (*.txt)|*.txt|XML Files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                var extension = System.IO.Path.GetExtension(openFileDialog.FileName);
                switch (extension)
                {
                    case ".txt":
                        ReadTxt(openFileDialog.FileName);
                        break;
                    case ".xml":
                        ReadXml(openFileDialog.FileName);
                        break;
                    default:
                        MessageBox.Show("Złe rozszerzenie");
                        break;
                }
            }
        }

        private void SaveTxt(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        foreach (var s in list)
                        {
                            writer.WriteLine(s.Imie);
                            writer.WriteLine(s.Nazwisko);
                            writer.WriteLine(s.NrIndeksu);
                            writer.WriteLine(s.Wydzial);
                            writer.WriteLine(s.oceny.Count);
                            foreach (var o in s.oceny)
                            {
                                writer.WriteLine(o.Przedmiot);
                                writer.WriteLine(o.Wartosc);
                            }
                        }
                    }
                }
                MessageBox.Show("Export danych zakończył się pomyślnie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadTxt(string path)
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                int liczbaOcen;
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        while(!reader.EndOfStream)
                        {
                            Student s = new Student();
                            s.Imie = reader.ReadLine();
                            s.Nazwisko = reader.ReadLine();
                            s.NrIndeksu = int.Parse(reader.ReadLine());
                            s.Wydzial = reader.ReadLine();

                            s.oceny = new ObservableCollection<Ocena>();
                            liczbaOcen = int.Parse(reader.ReadLine());
                            for(int i = 0; i < liczbaOcen; i++)
                            {
                                Ocena o = new Ocena();
                                o.Przedmiot = reader.ReadLine();
                                o.Wartosc = double.Parse(reader.ReadLine());
                                s.oceny.Add(o);
                            }
                            students.Add(s);
                        }
                    }
                }
                list = students;
                dg.ItemsSource = list;
                dg.Items.Refresh();
                MessageBox.Show("Import danych zakończył się pomyślnie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveXml(string path)
        {
            try
            {
                using(FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Student>));
                    xs.Serialize(fs, list);
                }
                MessageBox.Show("Export danych zakończył się pomyślnie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReadXml(string path)
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Student>));
                    students = (ObservableCollection<Student>)xs.Deserialize(fs);
                }
                list = students;
                dg.ItemsSource = list;
                dg.Items.Refresh();
                MessageBox.Show("Import danych zakończył się pomyślnie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
