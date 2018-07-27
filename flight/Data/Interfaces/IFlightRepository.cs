using flight.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Interfaces
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> Flights { get;  }
        Flight GetFlight(int Id);
        void AddFlight(Flight flight);
        void UpdateFlight(Flight flight);
    }
}
