using LiveFarmWPF.Model;
using LiveFarmWPF.ViewModel;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void RegistrButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }

        private void EnterHowGuestButton_Click(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.idUser = -1;
            Properties.Settings.Default.idRole = -1;
            Properties.Settings.Default.Save();
            this.NavigationService.Navigate(new CatalogWithoutBasketPage());
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UsersViewModel.CheckAuth(LoginBox.Text, PassBox.Password))
                {
                    Properties.Settings.Default.idUser = db.context.Users.FirstOrDefault(x => x.Login == LoginBox.Text).IdUser;
                    Properties.Settings.Default.idRole = db.context.Users.FirstOrDefault(x => x.Login == LoginBox.Text).RoleId;
                    Properties.Settings.Default.Save();
                    if (Properties.Settings.Default.idRole == 1) this.NavigationService.Navigate(new CatalogPage());
                    if (Properties.Settings.Default.idRole == 2) this.NavigationService.Navigate(new CatalogWithoutBasketPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
