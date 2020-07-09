using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonPieShop.Data.Models
{
    public class ShoppingCartItem
    {
        public long ShoppingCartItemId { get; set; }
        public Pie Pie { get; set; }
        public long Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
