using flight.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.ViewModels
{
    public class NewFlightViewModel
    {
        public int FlightId { get; set; }
        
        public int AircraftId { get; set; }

        public int AirportDepartId { get; set; }

        public int AirportDestinationId { get; set; }

        public double FuelNeeded { get; set; }

        public double Distance { get; set; }

        public IEnumerable<Aircraft> Aircrafts { get; set;}
        public IEnumerable<Airport> Airport { get; set;}

    }
}
