using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flight.Data.Interfaces;
using flight.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace flight.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFlightRepository _flightRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flightRepository"></param>
        public HomeController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var mv = new FlightsViewModel()
            {
                Flights = _flightRepository.Flights.OrderBy(f => f.FlightId)
            };
            return View(mv);

           
        }
    }
}