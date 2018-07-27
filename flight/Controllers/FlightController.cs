using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flight.Data.Interfaces;
using flight.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace flight.Controllers
{
  
    public class FlightController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IAirportRepository _airportRepository;

        public FlightController(IFlightRepository flightRepository,
                                IAircraftRepository aircraftRepository,
                                IAirportRepository airportRepository)
        {
            _flightRepository = flightRepository;
            _aircraftRepository = aircraftRepository;
            _airportRepository = airportRepository;
        }

        public IActionResult Index()
        {
            var mv = new FlightsViewModel()
            {
                Flights = _flightRepository.Flights.OrderBy(f => f.FlightId)
            };
            return View(mv);
        }

        public  ViewResult New()
        {
            var mv = new NewFlightViewModel()
            {
                Aircrafts = _aircraftRepository.Aircrafts.OrderBy(a => a.AircraftId),
                Airport = _airportRepository.Airports.OrderBy(a => a.Name)
            };
            return View("FlightForm", mv);
        }

        public ViewResult Save(NewFlightViewModel FlightMV)
        {
            var a = _airportRepository.GetAirport(FlightMV.Flight.AirportDepartId);
            var b = _airportRepository.GetAirport(FlightMV.Flight.AirportDestinId);
            var resultat = DistanceTo(a.Latitude, a.Longitude, b.Latitude, b.Longitude);
            return View("Index");
        }
        

        [HttpGet]
        [Route("/[controller]/Distance/{departId:int}/{destinationId:int}")]
        public double CalculerDistance(int departId, int destinationId)
        {
            if (departId > 0 && destinationId > 0)
            {
                var airportD = _airportRepository.GetAirport(departId);
                var airportA = _airportRepository.GetAirport(destinationId);
                var resultat = DistanceTo(airportD.Latitude, airportD.Longitude, airportA.Latitude, airportA.Longitude);
                return resultat;
            }
            else
                return 0;
        }

        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }
    }
}