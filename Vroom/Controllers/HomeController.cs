using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vroom.Models;

namespace Vroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VroomDbContext _dbContex;

        public HomeController(ILogger<HomeController> logger, VroomDbContext context)
        {
            _logger = logger;
            this._dbContex = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Bikes()
        {
            var BikeList = _dbContex.BikeModels.ToList();

           
            return View(BikeList);
        }
           
 
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }

