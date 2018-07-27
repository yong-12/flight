using flight.Data.Interfaces;
using flight.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Repisotories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDbContext _appDbContext;
        public FlightRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        IEnumerable<Flight> IFlightRepository.Flights =>
            _appDbContext.Flights.Include( a => a.Aircraft)
                                  .Include(a => a.AirportDepart)
                                  .Include(a => a.AirportDestination)
            .OrderBy(f => f.FlightId);

        void IFlightRepository.AddFlight(Flight flight)
        {
            _appDbContext.Flights.Add(flight);
            _appDbContext.SaveChanges();
        }

        Flight IFlightRepository.GetFlight(int Id)
        {
            return _appDbContext.Flights.Include(a => a.Aircraft)
                                  .Include(a => a.AirportDepart)
                                  .Include(a => a.AirportDestination)
                                  .FirstOrDefault(f => f.FlightId == Id);
        }

        void IFlightRepository.UpdateFlight(Flight flight)
        {
            var flightDB = _appDbContext.Flights.Single(f => f.FlightId == flight.FlightId);
            if (flightDB != null)
            {
                flightDB.AirportDepart = flight.AirportDepart;
                flightDB.AirportDestination = flight.AirportDestination;
                flightDB.Aircraft = flight.Aircraft;
                flightDB.FuelNeeded = flight.FuelNeeded;
                flightDB.Distance = flight.Distance;
                _appDbContext.SaveChanges();
            }
        }
    }
}
