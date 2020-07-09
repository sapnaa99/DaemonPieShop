using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaemonPieShop.Data.Interface;
using DaemonPieShop.Data.Models;
using DaemonPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DaemonPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            this._pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var homeviewmodel = new HomeViewModel()
            {
                PiesOfTheWeek = _pieRepository.PiesOfTheWeek
        };

            return View(homeviewmodel);
        }
    }
}
