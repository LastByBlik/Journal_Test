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
    /// Логика взаимодействия для AddGruppaWindow.xaml
    /// </summary>
    public partial class AddGruppaWindow : Window
    {
        public AddGruppaWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(nameBox.Text))
                errors.AppendLine("Укажите Группу");
            using (JournalContext db = new JournalContext())
            {

                Gruppa gruppa = new Gruppa()
                {
                    Gruppa1 = nameBox.Text,

                };
                db.Gruppas.Add(gruppa);
                db.SaveChanges();
                MessageBox.Show("Группа была добавлена");

            }
        }
    }
}
