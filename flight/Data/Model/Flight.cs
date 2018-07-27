using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Model
{
    public class Flight
    {
        public int FlightId { get; set; }

        public Aircraft Aircraft { get; set; }
        [Display(Name ="Aircraft")]
        public  int AircraftId { get; set; }

        public Airport AirportDepart { get; set; }
        [Display(Name ="Airport Depart")]
        public int AirportDepartId { get; set; }

        public Airport AirportDestin { get; set; }
        [Display(Name ="Airport Destination")]
        public int AirportDestinId { get; set; }

        [Display(Name = "Fuel Needed")]
        public double FuelNeeded { get; set; }

        public double Distance { get; set; }
    }
}
