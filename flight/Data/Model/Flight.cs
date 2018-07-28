using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual Airport AirportDepart { get; set; }

        [Display(Name ="Airport Depart")]
        public int AirportDepartId { get; set; }

        public virtual Airport AirportDestination { get; set; }

        [Display(Name ="Airport Destination")]
        public int AirportDestinationId { get; set; }

        [Display(Name = "Fuel Needed")]
        [Required]
        public double FuelNeeded { get; set; }

        [Display(Name = "Distance (Km)")]
        [Required]
        public double Distance { get; set; }
    }
}
