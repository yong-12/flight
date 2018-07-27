using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flight.Data.Interfaces;
using flight.Data.Model;
using flight.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace flight.Controllers
{
  
    public class AircraftController : Controller
    {
        private readonly IAircraftRepository _aircraftrepository;

        public AircraftController(IAircraftRepository aircraftrepository)
        {
            _aircraftrepository = aircraftrepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _aircraftrepository.Aircrafts;
            var vm = new AircraftViewModel()
            {
                Aircrafts = list
            };
            return View(vm);

        }

        public ViewResult New()
        {
            var aircraft = new Aircraft();
            return View("AircraftForm", aircraft);
        }

        [HttpPost]
        public  ActionResult Save(Aircraft aircraft)
        {
            if (aircraft.AircraftId ==0)
            {
                _aircraftrepository.Add(aircraft);
            }else
                _aircraftrepository.Update(aircraft);

            return RedirectToAction("Index");
        }

        

        public ActionResult Edit(int Id)
        {
            var aircraft =  _aircraftrepository.GetAircraft(Id);
            return View("AircraftForm", aircraft);
        }

        [HttpGet]
        public IEnumerable<Aircraft> GetList()
        {
            return _aircraftrepository.Aircrafts.ToList();
        }
    }
}