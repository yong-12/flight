using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Model
{
    public class Airport
    {
        public int AirportId { get; set; }
        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
