using LiveFarmWPF.Model;
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

namespace LiveFarmWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для ContentOrderPage.xaml
    /// </summary>
    public partial class ContentOrderPage : Page
    {
        Core db = new Core();
        public ContentOrderPage(int idOrder)
        {
            InitializeComponent();
            OrderContentListView.ItemsSource = db.context.ProductsInOrder.Where(x => x.OrderId == idOrder).ToList(); 
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OrdersPage());
        }
    }
}
