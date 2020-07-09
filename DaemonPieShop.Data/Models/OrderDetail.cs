using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonPieShop.Data.Models
{
    public class OrderDetail
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long PieId { get; set; }
        public long Amount { get; set; }
        public decimal Price { get; set; }
        public Pie Pie { get; set; }
        public Order Order { get; set; }
    }
}
