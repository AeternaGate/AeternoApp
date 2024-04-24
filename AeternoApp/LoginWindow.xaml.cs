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

namespace AeternoApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBoxPassword.Password.Trim();

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
            else
            {
                textBoxLogin.ToolTip = null;
                passwordBoxPassword.ToolTip = null;
                textBoxLogin.BorderBrush = Brushes.Black;
                passwordBoxPassword.BorderBrush = Brushes.Black;

                User loginUser = null;
                using (AppContext context = new AppContext()) 
                {
                    loginUser = context.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
                }

                if (loginUser != null)
                {
                    MessageBox.Show("Good!");

                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("User not found");
            }
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
