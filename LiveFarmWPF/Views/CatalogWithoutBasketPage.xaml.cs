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
    /// Логика взаимодействия для CatalogWithoutBasketPage.xaml
    /// </summary>
    public partial class CatalogWithoutBasketPage : Page
    {
        Core db = new Core();
        public CatalogWithoutBasketPage()
        {
            InitializeComponent();
            CatalogListView.ItemsSource = db.context.Assortment.ToList();
            PriceFilterComboBox.SelectedIndex = 0;
            MakerFilterComboBox.SelectedIndex = 0;
            UpdateAssortment();
        }
        private void UpdateAssortment()
        {
            List<Assortment> assortment = db.context.Assortment.ToList();
            if (PriceFilterComboBox.SelectedIndex == 0) assortment = assortment.OrderBy(x => x.FinalPrice).ToList();
            else assortment = assortment.OrderByDescending(x => x.FinalPrice).ToList();
            if (InStockCheckBox.IsChecked == true) assortment = assortment.Where(x => x.Quantity > 0).ToList();
            if (MakerFilterComboBox.SelectedIndex != 0) assortment = assortment.Where(x => x.MakerId == MakerFilterComboBox.SelectedIndex).ToList();
            assortment = assortment.Where(x => x.Title.ToLower().Contains(FindTextBox.Text.ToLower())).ToList();
            CatalogListView.ItemsSource = assortment;
        }

        private void PriceFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAssortment();
        }

        private void MakerFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAssortment();
        }

        private void InStockCheckedBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAssortment();
        }

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAssortment();
        }
    }
}
