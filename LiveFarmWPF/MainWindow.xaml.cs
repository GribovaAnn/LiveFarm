using LiveFarmWPF.Model;
using LiveFarmWPF.Properties;
using LiveFarmWPF.Views;
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

namespace LiveFarmWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //#00C2BF бирюзовый
        Core db = new Core();
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPage());
        }
        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            CatalogButton.Opacity = 1;
            BasketButton.Opacity = 1;
            OrdersButton.Opacity = 0.75;
            MainFrame.Navigate(new OrdersPage());
        }
        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {
            CatalogButton.Opacity = 0.75;
            BasketButton.Opacity = 1;
            OrdersButton.Opacity = 1;
            MainFrame.Navigate(new CatalogPage());
        }

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.idUser == -1)
            {
                MessageBox.Show("Для добавления товаров в коризну нужно авторизоваться");
                return;
            }
            CatalogButton.Opacity = 1;
            BasketButton.Opacity = 0.75;
            OrdersButton.Opacity = 1;
            MainFrame.Navigate(new BasketPage());
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.idUser = 0;
            Properties.Settings.Default.idRole = 0;
            Properties.Settings.Default.Save();
            MainFrame.Navigate(new AuthPage());
            MenuPanel.Visibility = Visibility.Collapsed;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.idUser == 0) 
            {
                MenuPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                MenuPanel.Visibility = Visibility.Visible;
            }
            if (Properties.Settings.Default.idUser == -1)
            {
                ExitButton.Visibility = Visibility.Collapsed;
                AuthButton.Visibility = Visibility.Visible;
                UserName.Text = $"Вы вошли как: Гость";
            }
            else
            {
                ExitButton.Visibility = Visibility.Visible;
                AuthButton.Visibility = Visibility.Collapsed;
            }
            if (Properties.Settings.Default.idUser != 0 && Properties.Settings.Default.idUser != -1)
            {
                UserName.Text = $"Вы вошли как: {db.context.Users.FirstOrDefault(x => x.IdUser == Properties.Settings.Default.idUser).Fname} {db.context.Users.FirstOrDefault(x => x.IdUser == Properties.Settings.Default.idUser).Sname}";
            }
            if (Settings.Default.idRole == 2)
            {
                BasketButton.Visibility = Visibility.Collapsed;
                OrdersButton.Visibility = Visibility.Visible;
            }
            else
            {
                BasketButton.Visibility = Visibility.Visible;
                OrdersButton.Visibility = Visibility.Visible;
            }
            if (Settings.Default.idRole == -1)
            {
                BasketButton.Visibility = Visibility.Collapsed;
                OrdersButton.Visibility = Visibility.Collapsed;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            WindowClosed(sender, e);
            MenuPanel.Visibility = Visibility.Collapsed;
            CatalogButton.Opacity = 0.75;
            BasketButton.Opacity = 1;
            OrdersButton.Opacity = 1;
            MainFrame.Navigate(new AuthPage());
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Properties.Settings.Default.idUser = 0;
            Properties.Settings.Default.idRole = 0;
            Properties.Settings.Default.Save();
        }
    }
}
