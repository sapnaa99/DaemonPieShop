using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaemonPieShop.Data.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
