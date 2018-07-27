using flight.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.ViewModels
{
    public class FlightsViewModel
    {
        public IEnumerable<Flight> Flights { get; set; }
    }
}
