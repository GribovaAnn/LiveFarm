using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LiveFarmWPF.Model
{
    public partial class Assortment
    {
        public string PriceText
        {
            get
            {
                return $"{Price}₽";
            }
        }
        public string DiscountText
        {
            get
            {
                if (Discount == 0 || Discount == null) return "";
                else return $"{Discount}%";
            }
        }
        public double FinalPrice
        {
            get
            {
                if (Discount == 0 || Discount == null) return Price;
                else return (double)(Price - (Price * (double)Discount / 100));
            }
        }
        public string PriceWithDiscount
        {
            get
            {
                if (Discount == 0 || Discount == null) return $"{(double)Price}₽";
                else return $"{(double)Price - ((double)Price * (double)Discount/100)}₽";
            }
        }
        public Visibility DiscountVisibility
        {
            get
            {
                if (Discount == 0 || Discount == null) return Visibility.Hidden;
                else return Visibility.Visible;
            }
        }
        public string QuantityText
        {
            get
            {
                return $"На складе: {Quantity}{Units.Name}";
            }
        }
        public string ColorQuantity
        {
            get
            {
                if (Quantity < 5) return "Red";
                else return "Black";
            }
        }
        public string DiscountLine
        {
            get
            {
                if (Discount == 0 || Discount == null) return "None";
                else return "Strikethrough";
            }
        }
    }
}
