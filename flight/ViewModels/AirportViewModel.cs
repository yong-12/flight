﻿using flight.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.ViewModels
{
    public class AirportViewModel
    {
        public IEnumerable<Airport> Airports { get; set; }
    }
}
