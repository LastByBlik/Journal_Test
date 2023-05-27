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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        async void disableButton()
        {
            LoginBut.IsEnabled = false;
            await Task.Delay(TimeSpan.FromSeconds(10));
            LoginBut.IsEnabled = true;
        }

        bool verify = true;
        int verifyCheck = 0;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBut_Click(object sender, RoutedEventArgs e)
        {
            using (JournalContext db = new JournalContext())
            {
                // проверка, если есть каптча
                if (captchaBlock.Visibility == Visibility.Visible)
                {
                    if (captchaBlock.Text == captchaBox.Text)
                    {
                        verify = true;
                    }
                }

                Authorization user = db.Authorizations.Where(u => u.Login == loginBox.Text && u.Password == passwordBox.Password).FirstOrDefault() as Authorization;


                // admin
                if (user != null && verify)
                {
                    new MainWindow().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неуспешная авторизация");
                    verifyCheck += 1;

                    // captcha view
                    captchaBox.Visibility = Visibility.Visible;
                    captchaBlock.Visibility = Visibility.Visible;
                    captchaBlock.Text = CaptchaBuilder.Refresh();
                    verify = false;

                    if (verifyCheck > 1)
                    {
                        disableButton();
                        captchaBlock.Text = CaptchaBuilder.Refresh();
                    }
                }
            }
        }
    }
}
