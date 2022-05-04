using RAIAPP.Utils;
using System;
using System.IO;
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
using RAIAPP.Views.Windows;

namespace RAIAPP.Views.Pages
{
    /// <summary>
    /// Interaction logic for pAuth.xaml
    /// </summary>
    public partial class pAuth : Page
    {
        public pAuth()
        {
            InitializeComponent();
            imgPass.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Resources/pass.png"));
        }

        private void tblShowPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pbPassword.Visibility = Visibility.Collapsed;
            tbPassword.Visibility = Visibility.Visible;
            tbPassword.Text = pbPassword.Password;
        }

        private void tblShowPassword_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pbPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Collapsed;
  
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbLogin.Text=="DEMO"&&pbPassword.Password=="DEMO")
                {
                    NavigationService.Navigate(new pDemo());
                }
                var currentUser = AppData.DB.Personals.FirstOrDefault(c=>c.PersonalLogin == tbLogin.Text
                && c.PersonalPassword == pbPassword.Password);

                if (currentUser != null)
                {
                    NavigationService.Navigate(new pMain(tbLogin.Text));
                }
                else if (tbLogin.Text != "DEMO")
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pGuest());
        }

        private void btnSignUP_Click(object sender, RoutedEventArgs e)
        {
            if (wAboutUser.Count == 0)
            {
                wAboutUser window = new wAboutUser();
                window.Show();
            }
        }
    }
}
