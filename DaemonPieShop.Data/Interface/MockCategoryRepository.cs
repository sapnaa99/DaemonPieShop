using DaemonPieShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaemonPieShop.Data.Interface
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category { CategoryId = 1, CategoryName="Fruit Pie",Description="All Fruits"},
                new Category { CategoryId = 2, CategoryName = "Cheese Cakes", Description="Cheesy all the way"},
                new Category { CategoryId= 3 , CategoryName = "Seasonal Pies", Description = "Get in mood for a seasonal pie" }
            };

      }
}
