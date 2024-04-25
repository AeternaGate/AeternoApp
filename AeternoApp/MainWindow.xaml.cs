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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AeternoApp
{
    public partial class MainWindow : Window
    {

        AppContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            string password = passwordBoxPassword.Password.Trim();
            string repeatPassword = passwordBoxRepeatPassword.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Login is too short";
                textBoxLogin.BorderBrush = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                passwordBoxPassword.ToolTip = "Password is too short";
                passwordBoxPassword.BorderBrush = Brushes.Red;
            }
            else if (repeatPassword != password)
            {
                passwordBoxRepeatPassword.ToolTip = "Passwords don't match";
                passwordBoxRepeatPassword.BorderBrush = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Wrong email";
                textBoxEmail.BorderBrush = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = null;
                textBoxEmail.ToolTip = null;
                passwordBoxPassword.ToolTip = null;
                passwordBoxRepeatPassword.ToolTip = null;
                textBoxLogin.BorderBrush = Brushes.Black;
                textBoxEmail.BorderBrush = Brushes.Black;
                passwordBoxPassword.BorderBrush = Brushes.Black;
                passwordBoxRepeatPassword.BorderBrush = Brushes.Black;

                MessageBox.Show("Good!");
                User user = new User(login, password, email);

                db.Users.Add(user);
                db.SaveChanges();

                OpenLoginWindow();
            }
        }

        private void Button_Window_Login_Click(object sender, RoutedEventArgs e)
        {
            OpenLoginWindow();
        }

       void OpenLoginWindow()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Hide();
        }
    }
}
