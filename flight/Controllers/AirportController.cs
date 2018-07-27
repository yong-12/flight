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
    public class AirportController : Controller
    {
        private readonly IAirportRepository _areportrepository;
        public AirportController(IAirportRepository areportrepository)
        {
            _areportrepository = areportrepository;
        }

        public IActionResult Index()
        {
            var List = _areportrepository.Airports;
            var mv = new AirportViewModel()
            {
                Airports = List
            };
            return View(mv);
        }

        public ViewResult New()
        {
            var airport = new Airport();
            return View("AirportForm", airport);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Airport airport)
        {
            if (airport.AirportId == 0)
            {
                _areportrepository.Add(airport);
            }
            else
                _areportrepository.Update(airport);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int Id)
        {
            var airport = _areportrepository.GetAirport(Id);
            return View("AirportForm", airport);
        }
    }
}