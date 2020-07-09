using DaemonPieShop.Data.DbContexts;
using DaemonPieShop.Data.Interface;
using DaemonPieShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonPieShop.Data.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly DaemonPieShopDbContext _context;
        public CategoryService(DaemonPieShopDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Category> AllCategories

        {
            get
            {
                return _context.Categories;
            }
        }
    }
}
