using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Model
{
    public class Aircraft
    {
        public int AircraftId { get; set; }

        [Required]
        [Display(Name ="Aircraft Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Fuel Comsumption")]
        public Double FuelComsumption { get; set; }
    }
}
