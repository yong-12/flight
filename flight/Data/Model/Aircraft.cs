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
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1,10000000)]
        [Display(Name = "Fuel Comsumption")]
        public Double FuelComsumption { get; set; }
    }
}
