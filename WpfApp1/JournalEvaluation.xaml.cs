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
    /// Логика взаимодействия для JournalEvaluation.xaml
    /// </summary>
    public partial class JournalEvaluation : Window
    {
        public JournalEvaluation()
        {
            InitializeComponent();
            using (JournalContext db = new JournalContext())
            {
                Journal.ItemsSource = db.JournalEvaluations.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
