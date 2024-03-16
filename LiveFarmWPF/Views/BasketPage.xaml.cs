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
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        Core db = new Core();
        public BasketPage()
        {
            InitializeComponent();
            PickPointComboBox.ItemsSource = db.context.PickupPoints.ToList();
            PickPointComboBox.DisplayMemberPath = "Adress";
            PickPointComboBox.SelectedValuePath = "IdPoint";
            PickPointComboBox.SelectedIndex = 0;
            UpdateData();
        }
        private void UpdateData()
        {
            BasketListView.ItemsSource = db.context.Basket.Where(x => x.UserId == Properties.Settings.Default.idUser).ToList();
            double summ = 0;
            foreach (var item in db.context.Basket.Where(x => x.UserId == Properties.Settings.Default.idUser).ToList())
            {
                summ += db.context.Assortment.Where(x => x.IdProduct == item.ProductId).FirstOrDefault().Price * item.Quantity;
            }
            PriceSummTextBlock.Text = summ.ToString();
            if (summ > 2000)
            {
                DiscountTextBlock.Text = "5%";
                PriceWithDiscountTextBlock.Text = (summ - summ * 0.05).ToString();
            }
            else
            {
                DiscountTextBlock.Text = "0%";
                PriceWithDiscountTextBlock.Text = summ.ToString();
            }
            if (db.context.Basket.Count() == 0)
            {
                BasketEmpty.Visibility = Visibility.Visible;
                BasketWithItems.Visibility = Visibility.Collapsed;
            }
            else
            {
                BasketEmpty.Visibility = Visibility.Collapsed;
                BasketWithItems.Visibility = Visibility.Visible;
            }
        }
        private void DeleteItemFromBasket(object sender, MouseButtonEventArgs e)
        {
            Image activeElement = sender as Image;
            Basket activeItem = activeElement.DataContext as Basket;
            db.context.Basket.Remove(activeItem);
            db.context.SaveChanges();
            UpdateData();
        }

        private void PlusQuantity_Click(object sender, MouseButtonEventArgs e)
        {
            TextBlock activeElemet = sender as TextBlock;
            Basket activeItem = activeElemet.DataContext as Basket;
            if (db.context.Assortment.FirstOrDefault(x => x.IdProduct == activeItem.ProductId).Quantity < activeItem.Quantity + 1) MessageBox.Show("Доставка задержится, так как товара нет в наличии");
            activeItem.Quantity++;
            db.context.SaveChanges();
            UpdateData();
        }

        private void MinusQuantity_Click(object sender, MouseButtonEventArgs e)
        {
            TextBlock activeElemet = sender as TextBlock;
            Basket activeItem = activeElemet.DataContext as Basket;
            if (activeItem.Quantity == 1) db.context.Basket.Remove(activeItem);
            else activeItem.Quantity--;
            db.context.SaveChanges();
            UpdateData();
        }

        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            bool inStock = true;
            foreach (var item in db.context.Basket.Where(x => x.UserId == Properties.Settings.Default.idUser))
            {
                if (item.Quantity > db.context.Assortment.FirstOrDefault(x => x.IdProduct == item.ProductId).Quantity)
                {
                    inStock = false;
                    break;
                }
            }
            Orders newOrder = new Orders()
            {
                UserId = Properties.Settings.Default.idUser,
                PointId = (int)PickPointComboBox.SelectedValue,
                StatusId = 1,
                DateOrder = DateTime.Now.ToString(),
                InStock = inStock,
            };
            db.context.Orders.Add(newOrder);
            db.context.SaveChanges();
            foreach (var item in db.context.Basket.Where(x => x.UserId == Properties.Settings.Default.idUser))
            {
                ProductsInOrder productsInOrder = new ProductsInOrder()
                {
                    UserId = item.UserId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    OrderId = newOrder.IdOrder,
                };
                db.context.ProductsInOrder.Add(productsInOrder);
            }
            foreach (var item in db.context.Basket.Where(x => x.UserId == Properties.Settings.Default.idUser))
            {
                if (item.Quantity > db.context.Assortment.FirstOrDefault(x => x.IdProduct == item.ProductId).Quantity)
                {
                    db.context.Assortment.FirstOrDefault(x => x.IdProduct == item.ProductId).Quantity = 0;
                }
                else
                {
                    db.context.Assortment.FirstOrDefault(x => x.IdProduct == item.ProductId).Quantity -= item.Quantity;
                }
                db.context.Basket.Remove(item);
            }
            db.context.SaveChanges();
            UpdateData();
            MessageBox.Show("Вы успешно формили заказ!");
        }
    }
}
