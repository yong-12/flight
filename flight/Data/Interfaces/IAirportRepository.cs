using flight.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Interfaces
{
    public interface IAirportRepository
    {
        IEnumerable<Airport> Airports { get; }
        int Add(Airport airport);
        int Update(Airport airport);
        Airport GetAirport(int Id);
        bool Remove(int id);
    }
}
