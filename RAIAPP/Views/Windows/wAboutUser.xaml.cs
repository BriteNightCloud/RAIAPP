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
using RAIAPP.Utils;
using RAIAPP.Models;

namespace RAIAPP.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для wAboutUser.xaml
    /// </summary>
    public partial class wAboutUser : Window
    {
        public wAboutUser()
        {
            InitializeComponent();
            _count++;

            btnEnd.Click += Button_RegClick;
            btnEnd.Content = "Регистрация";
        }

        public wAboutUser(Personal user)
        {
            InitializeComponent();
            _user = user;
            _count++;

            tbLogin.IsEnabled = false;
            pbPassword.IsEnabled = false;
            tbFirstName.IsEnabled = false;
            tbLastName.IsEnabled = false;
            tbMiddleName.IsEnabled = false;
            tbPhone.IsEnabled = false;

            btnEnd.Click += Button_CloseClick;
            btnEnd.Content = "Закрыть";
        }

        private Personal _user;

        private void Window_Closed(object sender, EventArgs e)
        {
            _count--;
        }

        static int _count;
        public static int Count
        {
            get
            {
                return _count;
            }
        }

        private void Button_RegClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text) || string.IsNullOrWhiteSpace(tbMiddleName.Text)
             || string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(pbPassword.Password) || string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Поля не должны быть пустыми!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Personal newUser = new Personal();
            
            if (AppData.DB.Personals.ToList().Where(c => c.PersonalLogin.ToLower() == tbLogin.Text.ToLower()).Count() == 0)
            {
                newUser.FirstName = tbFirstName.Text;
                newUser.LastName = tbLastName.Text;
                newUser.MiddleName = tbMiddleName.Text;
                newUser.PersonalLogin = tbLogin.Text;
                newUser.PersonalPassword = pbPassword.Password;
                newUser.PersonalPhone = tbPhone.Text;

                AppData.DB.Personals.Add(newUser);
                AppData.DB.SaveChanges();

                Close();
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
