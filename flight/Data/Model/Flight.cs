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

        [Display(Name ="Aircraft :")]
        public  int AircraftId { get; set; }

        public virtual Airport AirportDepart { get; set; }

        [Display(Name ="Airport Depart :")]
        public int AirportDepartId { get; set; }

        public virtual Airport AirportDestination { get; set; }

        [Display(Name ="Airport Destination :")]
        public int AirportDestinationId { get; set; }

        
        [Required]
        [Display(Name = "Fuel Needed in Liter :")]
        public double FuelNeeded { get; set; }

       
        [Required]
        [Display(Name = "Distance (Km) :")]
        public double Distance { get; set; }
    }
}
