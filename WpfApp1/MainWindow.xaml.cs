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
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            using (JournalContext db = new JournalContext())
            {
                Journal.ItemsSource = db.Gruppas.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Journal main = new Journal();
            main.Show();
            this.Close();
        }

        private void addOrderButtonClick(object sender, RoutedEventArgs e)
        {
            using (JournalContext db = new JournalContext())
            {
                var student = (Journal.SelectedItem) as Gruppa;
                if (student != null)
                {
                    if (MessageBox.Show($"Вы точно хотите удалить {student.Surname}", "Внимание!",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        db.Gruppas.Remove(student);
                        db.SaveChanges();
                        MessageBox.Show($"Студент {student.Surname} удален(а)!");
                        Journal.ItemsSource = db.Gruppas.ToList();
                    }
                }
            }
        }

        private void searchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            using JournalContext db = new JournalContext();
            {
                var currentgruppas = db.Gruppas.ToList();
                Journal.ItemsSource = db.Gruppas.Where(db => db.Name.Contains(searchBox.Text) ||  db.Surname.Contains(searchBox.Text) || db.Patronymic.Contains(searchBox.Text) || db.Gruppa1.Contains(searchBox.Text)).ToList();
            }
            
        }
        private void сlearButton_Click(object sender, RoutedEventArgs e)
        {

            using (JournalContext db = new JournalContext())
            {
                Journal.ItemsSource = db.Gruppas.ToList();
            }
            searchBox.Text = string.Empty;
        }

        private void addOrderButtonClick1(object sender, RoutedEventArgs e)
        {
            new AddStudentWindow(null).ShowDialog();


        }

        private void editUser_Click(object sender, RoutedEventArgs e)
        {
            
            Gruppa g = Journal.SelectedItem as Gruppa;
            //AddStudentWindow main = new AddStudentWindow();
            //main.ShowDialog();
            new AddStudentWindow(g).ShowDialog();
        }

        private void Journal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Gruppa g = Journal.SelectedItem as Gruppa;
            new AddStudentWindow(g).ShowDialog();
        }
    }
}
