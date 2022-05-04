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
    /// Interaction logic for pMain.xaml
    /// </summary>
    public partial class pMain : Page
    {
        private string CurrentLogin;

        public pMain(string login)
        {
            InitializeComponent();
            CurrentLogin = login;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            if (AppData.DB.Personals.ToList().Where(c => c.PersonalLogin == CurrentLogin && c.isAdmin == true).Count() == 0)
            {
                btnAdmin.IsEnabled = false;
                btnAdmin.Visibility = Visibility.Collapsed;
            }
            GetData(tbSearch.Text, cmbFilter.Text);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetData(tbSearch.Text, cmbFilter.Text);
        }

        private void GetData(string search ="", string filter= "")
        {
            var data = AppData.DB.Orders.ToList();
            int countBefore = data.Count;
            if (!string.IsNullOrEmpty(search)&&!string.IsNullOrWhiteSpace(search))
            {
                data = data.Where(c => c.Auto.StateNumber.ToLower().Contains(search.ToLower())
                || c.Auto.Client.FullName.ToLower().Contains(search.ToLower())
                || c.Auto.Model.Mark.MarkName.ToLower().Contains(search.ToLower())
                || c.Auto.Model.ModelName.ToLower().Contains(search.ToLower())).ToList();
            }
            if (filter!="Все")
            {
                data = data.Where(c => c.Status.StatusName == filter).ToList();
            }
            int countAfter = data.Count;
            dgOrders.ItemsSource = data;
            tblCountRecord.Text = $"{countAfter} из {countBefore}";
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetData(tbSearch.Text, ((ComboBoxItem)cmbFilter.SelectedValue).Content.ToString());
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
