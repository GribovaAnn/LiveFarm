using LiveFarmWPF.Model;
using LiveFarmWPF.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace LiveFarmWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        Core db = new Core();
        public OrdersPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.idRole == 1)
            {
                if (db.context.Orders.Where(x => x.UserId == Properties.Settings.Default.idUser).Count() == 0)
                {
                    OrdersFilled.Visibility = Visibility.Collapsed;
                    OrdersEmpty.Visibility = Visibility.Visible;
                }
                else
                {
                    OrdersFilled.Visibility = Visibility.Visible;
                    OrdersEmpty.Visibility = Visibility.Collapsed;
                }
            }
            if (Properties.Settings.Default.idRole == 2) OrderListView.ItemsSource = db.context.Orders.ToList();
            if (Properties.Settings.Default.idRole == 1) OrderListView.ItemsSource = db.context.Orders.Where(x => x.UserId == Properties.Settings.Default.idUser).ToList();
        }

        private void ImportToPdf_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Orders activeOrder = activeButton.DataContext as Orders;
            OrdersViewModel.MakingPdf(activeOrder.IdOrder);
            MessageBox.Show("Файл создан");
        }

        private void ContentOfOrder_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Orders activeOrder = activeButton.DataContext as Orders;
            this.NavigationService.Navigate(new ContentOrderPage(activeOrder.IdOrder));
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Orders activeOrder = activeButton.DataContext as Orders;
            foreach (var item in db.context.ProductsInOrder.Where(x => x.OrderId == activeOrder.IdOrder))
            {
                db.context.ProductsInOrder.Remove(item);
            }
            db.context.Orders.Remove(activeOrder);
            db.context.SaveChanges();
            OrderListView.ItemsSource = db.context.Orders.ToList();
            MessageBox.Show("Заказ удален");
        }
    }
}
