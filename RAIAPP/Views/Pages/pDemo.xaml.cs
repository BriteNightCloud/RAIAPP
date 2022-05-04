using RAIAPP.Utils;
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

namespace RAIAPP.Views.Pages
{
    /// <summary>
    /// Interaction logic for pDemo.xaml
    /// </summary>
    public partial class pDemo : Page
    {
        public pDemo()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lvOrders.ItemsSource = AppData.DB.Orders.ToList();
        }
    }
}
