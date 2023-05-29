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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        public Journal()
        {
            InitializeComponent();
            using (JournalContext db = new JournalContext())
            {
                ProductListView.ItemsSource = db.Fios.ToList();
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            new MainWindow().Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddGruppaWindow main = new AddGruppaWindow();
            main.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //using (JournalContext db = new JournalContext())
            //{
            //    var student = (Journal.SelectedItem) as Gruppa;
            //    if (student != null)
            //    {
            //        if (MessageBox.Show($"Вы точно хотите удалить {student.Surname}", "Внимание!",
            //            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //        {
            //            db.Gruppas.Remove(student);
            //            db.SaveChanges();
            //            MessageBox.Show($"Студент {student.Surname} удален(а)!");
            //            Journal.ItemsSource = db.Gruppas.ToList();
            //        }
            //    }
            //}
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new JournalEvaluation().Show();
            this.Close();
        }
    }
}
