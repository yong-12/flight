using flight.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flight.ViewModels
{
    public class NewFlightViewModel
    {
        public int FlightId { get; set; }

        [Display(Name = "Aircraft :")]
        public int AircraftId { get; set; }

        [Display(Name = "Airport Depart :")]
        public int AirportDepartId { get; set; }

        [Display(Name = "Airport Destination :")]
        public int AirportDestinationId { get; set; }

        [Display(Name = "Fuel Needed in Liter :")]
        public double FuelNeeded { get; set; }

        [Display(Name = "Distance (Km) :")]
        public double Distance { get; set; }

        public IEnumerable<Aircraft> Aircrafts { get; set;}
        public IEnumerable<Airport> Airport { get; set;}

    }
}
