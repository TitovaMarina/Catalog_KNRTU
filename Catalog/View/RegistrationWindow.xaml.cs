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
using Catalog.DAL.Model;
using Catalog.DAL;

namespace Catalog
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        UsersDatabase db;
        public RegistrationWindow()
        {
            InitializeComponent();
            db = new UsersDatabase();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            User registeredUser = new User(
                    NameTextBox.Text,
                    LastNameTextBox.Text,
                    DateTime.Now,
                    LoginTextBox.Text,
                    PasswordTextBox.Text);

            bool IsRegistered = db.Register(registeredUser);
            
            if (IsRegistered)
            {
                MessageBox.Show("Пользователь успешно зарегистрирован в системе!", "Ура!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                LoginTextBox.BorderBrush = Brushes.Red;
                LoginTextBox.BorderThickness = new Thickness(3);
                MessageBox.Show("Пользователь с таким логином уже существует, выберите другой логин.",
                    "Упс!", MessageBoxButton.OK, MessageBoxImage.Information);
            }       
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
