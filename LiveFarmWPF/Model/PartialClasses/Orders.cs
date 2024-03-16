using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LiveFarmWPF.Model
{
    public partial class Orders
    {
        public string NumberOfOrder
        {
            get
            {
                return $"Номер заказа: 00{IdOrder}";
            }
        }
        public string DateMaking
        {
            get
            {
                return $"Дата оформления: {DateTime.Parse(DateOrder).ToShortDateString()}";
            }
        }
        public string DateComming
        {
            get
            {
                if (InStock) return $"Дата прибытия: {DateTime.Parse(DateOrder).AddDays(2).ToShortDateString()}";
                else return $"Дата прибытия: {DateTime.Parse(DateOrder).AddDays(5).ToShortDateString()}";
            }
        }
        public string PickupPoint
        {
            get
            {
                return $"Пункт выдачи: {PickupPoints.Adress}";
            }
        }
        public string StatusOfOrder
        {
            get
            {
                return $"Статус заказа: {MakingStatuses.Name}";
            }
        }
        public Visibility VisibilityWorkerContent
        {
            get
            {
                if (Properties.Settings.Default.idRole == 2) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }
        public Visibility UnvisibilityWorkerContent
        {
            get
            {
                if (Properties.Settings.Default.idRole == 1) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }
        public string UserName
        {
            get
            {
                return $"Заказал: {Users.Fname} {Users.Sname}";
            }
        }
    }
}
