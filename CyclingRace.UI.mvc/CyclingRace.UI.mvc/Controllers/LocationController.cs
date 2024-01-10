using CyclingRace.Model;
using CyclingRace.Services;
using Microsoft.AspNetCore.Mvc;

namespace CyclingRace.UI.mvc.Controllers
{
    public class LocationController(LocationService locationService, SignalmanService signalmanService) : Controller
    {
        public IActionResult Index()
        {
            var people = locationService.Find();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Signalmen = signalmanService.Find();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Location location)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Signalmen = signalmanService.Find();
                return View(location);
            }

            locationService.Create(location);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var location = locationService.Get(id);
            ViewBag.Signalmen = signalmanService.Find();
            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Signalmen = signalmanService.Find();
                return View(location);
            }

            locationService.Update(id, location);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var person = locationService.Get(id);
            return View(person);
        }

        [HttpPost("/location/delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            locationService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
