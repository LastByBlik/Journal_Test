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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        Gruppa? currentgruppa;
        public AddStudentWindow(Gruppa g)
        {
            InitializeComponent();

            this.Title = "Добавление студентов";
            Gruppa gruppa= new Gruppa();
            if(g != null)
            {
                currentgruppa = g;
                this.Title = "Редактирование студента";
                DataContext = g;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(nameBox.Text))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(surnameBox.Text))
                errors.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(PatronymicBox.Text))
                errors.AppendLine("Укажите Отчество");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            using (JournalContext db = new JournalContext())
            {
                if(currentgruppa == null)
                {
                    DateTime dt = Convert.ToDateTime(DateTime.Now.ToLongDateString());

                    try
                    {
                        
                        Gruppa gruppa = new Gruppa()
                        {
                            Surname = surnameBox.Text,
                            Name = nameBox.Text,
                            Patronymic = PatronymicBox.Text,
                            Evaluation = Convert.ToInt32 (EvaluationBox.Text),
                            Gruppa1 = gruppaBox.Text,
                            OffsetNotOffset = offsetnotoffsetBox.Text,
                            Data = Convert.ToString(dt),
                            
                        };
                        db.Gruppas.Add(gruppa);
                        db.SaveChanges();
                        MessageBox.Show("Студент был добавлен");
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.InnerException.ToString());
                    }
                }
                else
                {
                    try
                    {
                        db.Gruppas.Update(currentgruppa);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException.ToString());
                    }
                }
                
            }
        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
