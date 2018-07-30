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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDbContext"></param>
        public FlightRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Flight list
        /// </summary>
        IEnumerable<Flight> IFlightRepository.Flights =>
            _appDbContext.Flights.Include( a => a.Aircraft)
                                  .Include(a => a.AirportDepart)
                                  .Include(a => a.AirportDestination)
            .OrderBy(f => f.FlightId);

        /// <summary>
        ///  To Add a new flight
        /// </summary>
        /// <param name="flight"></param>
        void IFlightRepository.AddFlight(Flight flight)
        {
            _appDbContext.Flights.Add(flight);
            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Get Flight by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Flight IFlightRepository.GetFlight(int Id)
        {
            return _appDbContext.Flights.Include(a => a.Aircraft)
                                  .Include(a => a.AirportDepart)
                                  .Include(a => a.AirportDestination)
                                  .FirstOrDefault(f => f.FlightId == Id);
        }

        /// <summary>
        /// To Update flight
        /// </summary>
        /// <param name="flight"></param>
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

        /// <summary>
        /// To Delete Flight
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Remove(int Id)
        {
            try
            {
                var FlightDB = _appDbContext.Flights.FirstOrDefault(a => a.FlightId == Id);
                if (FlightDB == null)
                    return false;
                _appDbContext.Remove(FlightDB);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            
        }
    }
}
