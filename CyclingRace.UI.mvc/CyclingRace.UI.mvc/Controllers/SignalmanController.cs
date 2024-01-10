using CyclingRace.Model;
using CyclingRace.Services;
using Microsoft.AspNetCore.Mvc;

namespace CyclingRace.UI.mvc.Controllers
{
    public class SignalmanController(LocationService locationService, SignalmanService signalmanService) : Controller
    {
        public IActionResult Index()
        {
            var signalmen = signalmanService.Find();
            return View(signalmen);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Locations = locationService.Find(); 
            return SignalmanView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Signalman signalman)
        {
            if (!ModelState.IsValid)
            {
                return SignalmanView(signalman);
            }

            signalmanService.Create(signalman);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            ViewBag.Locations = locationService.Find();
            var signalman = signalmanService.Get(id);
            return SignalmanView(signalman);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Signalman signalman)
        {
            if (!ModelState.IsValid)
            {
                return SignalmanView(signalman);
            }

            signalmanService.Update(id, signalman);

            return RedirectToAction("Index", "Home");
        }

        private IActionResult SignalmanView(Signalman? signalman = null)
        {
            var signalmen = signalmanService.Find();
            ViewBag.Signalmen = signalmen;
            ViewBag.Locations = locationService.Find();
            if (signalman is null)
            {
                return View();
            }

            return View(signalman);
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var signalman = signalmanService.Get(id);
            return View(signalman);
        }

        [HttpPost("/signalman/delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            signalmanService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
