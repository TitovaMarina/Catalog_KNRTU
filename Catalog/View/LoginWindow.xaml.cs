using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Catalog.DAL;

namespace Catalog
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static string userLogin;
        private static string userDB;

        UsersDatabase db;
        public LoginWindow()
        {
            InitializeComponent();
            db = new UsersDatabase();
        }

        public string GetUserLogin 
        { 
            get { return userLogin;  }
            set { userLogin = LogintextBox.Text; } 
        }

        public string GetUserDB
        {
            get { return userDB; }
            set { userDB = LogintextBox.Text + ".sqlite"; }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //warningLabel.Visibility = Visibility.Hidden;
            try
            {
                bool IsAuthorized = db.Authorize(LogintextBox.Text, PasswordBox.Password);

                if (IsAuthorized && !String.IsNullOrEmpty(LogintextBox.Text))
                {
                    MainWindow mainWindow = new MainWindow(LogintextBox.Text);
                    this.Close();
                    mainWindow.ShowDialog();
                }
                else
                {
                    warningLabel.Content = "Неверный логин или пароль.";
                    warningLabel.FontSize = 12;
                    warningLabel.Visibility = Visibility.Visible;
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);

                warningLabel.Content = "Что-то пошло не так. Такого логина видимо нет." + ex.Message;
                warningLabel.Visibility = Visibility.Visible;

            }

        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            warningLabel.Visibility = Visibility.Hidden;
            LogintextBox.Text = String.Empty;
            PasswordBox.Password = String.Empty;
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }

        private void LogintextBox_KeyDown(object sender, KeyEventArgs e)
        {
            warningLabel.Visibility = Visibility.Hidden;
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            warningLabel.Visibility = Visibility.Hidden;
        }
    }
}
