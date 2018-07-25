using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Model
{
    public class Flight
    {
        public int FlightId { get; set; }
        public Aircraft Aircraft { get; set; }
        public Airport AirportDepart { get; set; }
        public Airport AirportDestin { get; set; }
        public double FuelNeeded { get; set; }
        public double Distance { get; set; }
    }
}
