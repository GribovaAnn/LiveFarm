using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveFarmWPF.Model
{
    public partial class ProductsInOrder
    {
        public string QuantityText
        {
            get
            {
                return $"x{Quantity}";
            }
        }
    }
}
