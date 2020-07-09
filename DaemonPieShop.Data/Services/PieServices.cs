using DaemonPieShop.Data.DbContexts;
using DaemonPieShop.Data.Interface;
using DaemonPieShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaemonPieShop.Data.Services
{
    public class PieServices : IPieRepository
    {
        private readonly DaemonPieShopDbContext _context;

        public PieServices(DaemonPieShopDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Pie> AllPies
        {
            get {
                return _context.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get {
                return _context.Pies.Include(c => c.Category).Where(x=>x.IsPieOfTheWeek == true);
            }
        }

        public Pie GetPieById(long? PieId)
        {
            return _context.Pies.FirstOrDefault(x => x.PieId == PieId);
        }
    }
}
