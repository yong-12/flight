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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aircraftrepository"></param>
        public AircraftController(IAircraftRepository aircraftrepository)
        {
            _aircraftrepository = aircraftrepository;
        }

        /// <summary>
        /// aircraft list
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// new aircraft
        /// </summary>
        /// <returns></returns>
        public ViewResult New()
        {
            var aircraft = new Aircraft();
            return View("AircraftForm", aircraft);
        }

        /// <summary>
        /// Save or update aircraft data
        /// </summary>
        /// <param name="aircraft"></param>
        /// <returns></returns>
        [HttpPost]
        public  ActionResult Save(Aircraft aircraft)
        {
            //validation Form 
            if (!ModelState.IsValid)
            {
                return View("AircraftForm", aircraft);
            }

            //If it is new a aircraft we save it in the data base
            //if its not the case, we update the aircraft 
            if (aircraft.AircraftId ==0)
            {
                _aircraftrepository.Add(aircraft);
            }else
                _aircraftrepository.Update(aircraft);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Data recuperation for aircraft edition
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public ActionResult Edit(int Id)
        {
            var aircraft =  _aircraftrepository.GetAircraft(Id);
            return View("AircraftForm", aircraft);
        }


        /// <summary>
        /// Api Get aircraft list 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Aircraft> GetList()
        {
            return _aircraftrepository.Aircrafts.ToList();
        }
    }
}