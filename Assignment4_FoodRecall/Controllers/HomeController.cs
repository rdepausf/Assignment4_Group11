using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment4_FoodRecall.Models;
using Assignment4_FoodRecall.APIHandlerManager;
using Newtonsoft.Json;

namespace Assignment4_FoodRecall.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About";
            return View();
        }

        public IActionResult Information()
        {
            APIHandler webHandler = new APIHandler();
            var a = webHandler.GetData();
            ViewData["Message"] = "Information";
            return View();
        }

        public ActionResult Visualization()
        {
            List<Visualization> dataPoints = new List<Visualization>();

            dataPoints.Add(new Visualization("Class I", 30));
            dataPoints.Add(new Visualization("Class II", 37));
            dataPoints.Add(new Visualization("Class III", 14));
          
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
