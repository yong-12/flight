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
            var NewFlight = new Flight();
            NewFlight = FlightMV.Flight;
            if (FlightMV.Flight.FlightId == 0 )
            {
                _flightRepository.AddFlight(NewFlight);
            }
            else
                _flightRepository.UpdateFlight(NewFlight);

            var mv = new FlightsViewModel()
            {
                Flights = _flightRepository.Flights.OrderBy(f => f.FlightId)
            };

            return View("Index", mv);
        }
        
        public ViewResult Edit(int Id)
        {

            var mv = new NewFlightViewModel()
            {
                Flight = _flightRepository.GetFlight(Id),
                Aircrafts = _aircraftRepository.Aircrafts.OrderBy(a => a.AircraftId),
                Airport = _airportRepository.Airports.OrderBy(a => a.Name)
            };
             
            return View("FlightForm",mv);
        }

        [HttpGet]
        [Route("/[controller]/Edit/calculer/{depart}/{destination}/{Aircraf}")]
        [Route("/[controller]/calculer/{depart}/{destination}/{Aircraf}")]
        public IDictionary<string, string> CalculerDistanceAndConsumption(int depart, int destination, int Aircraf)
        {
            // Fonction avec Dictionary
            var dictionary = new Dictionary<string, string>();
            var _distance = CalculerDistance(depart, destination);
            dictionary.Add("distance", Convert.ToString(_distance).Replace('.',','));
            var _consumption = Consumption(_distance, Aircraf);
            dictionary.Add("consumption", Convert.ToString(_consumption).Replace('.', ','));
            return dictionary;
        }

        [HttpGet]
        [Route("/[controller]/Consumption/{Distance}/{AircrafId}")]
        public double Consumption(double Distance , int AircrafId)
        {
            if (Distance> 0 && AircrafId > 0)
            {
                var Airraft = _aircraftRepository.GetAircraft(AircrafId);
                if(Airraft != null)
                {
                    if(Airraft.FuelComsumption > 0)
                    {
                        return Distance / Airraft.FuelComsumption;
                    }
                }
            }
            return 0;
        }

        [HttpGet]
        [Route("/[controller]/Distance/{depart}/{destination}")]
        public double CalculerDistance(int depart, int destination)
        {
            if (depart > 0 && destination > 0)
            {
                var airportD = _airportRepository.GetAirport(depart);
                var airportA = _airportRepository.GetAirport(destination);
                var resultat = DistanceTo(airportD.Latitude, airportD.Longitude, airportA.Latitude, airportA.Longitude);
                return resultat;
            }
            else
                return 0;
        }

        private static double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
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