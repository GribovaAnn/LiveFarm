using LiveFarmWPF.Model;
using LiveFarmWPF.Properties;
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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        Core db = new Core();
        public CatalogPage()
        {
            InitializeComponent();
            CatalogListView.ItemsSource = db.context.Assortment.ToList();
            PriceFilterComboBox.SelectedIndex = 0;
            MakerFilterComboBox.SelectedIndex = 0;
            UpdateAssortment();
        }

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.idUser == -1)
            {
                MessageBox.Show("Для добавления товаров в коризну нужно авторизоваться");
                return;                
            }
            Button activeElement  = sender as Button;
            Assortment activeProduct = activeElement.DataContext as Assortment;
            if (db.context.Basket.Where(x => x.ProductId == activeProduct.IdProduct).Count() > 0)
            {
                if (db.context.Assortment.FirstOrDefault(x => x.IdProduct == activeProduct.IdProduct).Quantity < db.context.Basket.FirstOrDefault(x => x.ProductId == activeProduct.IdProduct).Quantity+1)
                {
                    MessageBox.Show("Товар добавлен, но так как его нет на складе, доставка задержится");
                }
                db.context.Basket.FirstOrDefault(x => x.ProductId == activeProduct.IdProduct).Quantity++;
            }
            else
            {
                Basket pruduct = new Basket()
                {
                    UserId = Settings.Default.idUser,
                    ProductId = activeProduct.IdProduct,
                    Quantity = 1,
                };
                db.context.Basket.Add(pruduct);
            }         
            db.context.SaveChanges();
            if (activeProduct.Quantity == 0) MessageBox.Show("Товар добавлен, но так как его нет на складе, доставка задержится");
            else MessageBox.Show("Добавлено в корзину!");
        }

        private void PriceFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAssortment();
        }

        private void MakerFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAssortment();
        }

        private void InStockCheckedBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAssortment();
        }
    }
}
