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
                MessageBox.Show("Pick student");
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
            FileStream fs = new FileStream("data.bin", FileMode.Create);
            List<Student> students = list.ToList();
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, students);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        private void Load_Data_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("data.bin", FileMode.Open);
            List<Student> students = new List<Student>();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                students = bf.Deserialize(fs) as List<Student>;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
            list.Clear();
            foreach(var s in students)
                list.Add(s);
            dg.Items.Refresh();
        }
    }
}
