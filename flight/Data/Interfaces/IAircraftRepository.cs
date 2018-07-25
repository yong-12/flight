using flight.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Interfaces
{
    public interface IAircraftRepository
    {
        IEnumerable<Aircraft> Aircrafts { get; }
        int Add(Aircraft aircraft);
        Aircraft GetAircraft(int id);
        int Update(Aircraft aircraft);
        
    }
}
