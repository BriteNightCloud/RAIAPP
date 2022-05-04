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
using RAIAPP.Utils;

namespace RAIAPP.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для pGuest.xaml
    /// </summary>
    public partial class pGuest : Page
    {
        public pGuest()
        {
            InitializeComponent();
        }

        // Запускается при загрузке страницы и заполняет DataGrid
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        //Хуйня пиздит значения из БД и пихает в dgCosts
        private void GetData()
        {
            var data = AppData.DB.Services.ToList();
            dgCosts.ItemsSource = data;
        }
    }
}
