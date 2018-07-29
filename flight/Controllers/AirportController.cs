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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="areportrepository"></param>
        public AirportController(IAirportRepository areportrepository)
        {
            _areportrepository = areportrepository;
        }

        /// <summary>
        /// Airport List redirection
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var List = _areportrepository.Airports;
            var mv = new AirportViewModel()
            {
                Airports = List
            };
            return View(mv);
        }

        /// <summary>
        /// Create new airport
        /// </summary>
        /// <returns></returns>
        public ViewResult New()
        {
            var airport = new Airport();
            return View("AirportForm", airport);
        }

        /// <summary>
        /// Save or Update airport Data
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return View("AirportForm", airport);
            }
        
            if (airport.AirportId == 0)
            {
                _areportrepository.Add(airport);
            }
            else
                _areportrepository.Update(airport);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Data recuperation for airport edition
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Edit(int Id)
        {
            var airport = _areportrepository.GetAirport(Id);
            return View("AirportForm", airport);
        }


        /// <summary>
        /// Api Get airport list 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Airport> GetList()
        {
            return _areportrepository.Airports.ToList();
        }

    }
}