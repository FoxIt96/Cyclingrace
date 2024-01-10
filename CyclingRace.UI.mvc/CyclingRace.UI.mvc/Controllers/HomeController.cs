using CyclingRace.Services;
using CyclingRace.UI.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CyclingRace.UI.mvc.Controllers
{
    public class HomeController(LocationService locationService, SignalmanService signalmanService) : Controller
    {
       


        public IActionResult Index()
        {
            ViewBag.Locations = locationService.Find();
            ViewBag.Signalmen = signalmanService.Find();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
