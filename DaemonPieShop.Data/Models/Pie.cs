using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DaemonPieShop.Data.Models
{
    public class Pie
    {
        public long PieId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AlleryInformation { get; set; }

       
        public decimal Size { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public long? CategoryId { get; set; }
        public Category Category { get; set; }      
        public string Notes { get; set; }
    }

   
}
