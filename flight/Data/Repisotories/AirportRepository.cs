using flight.Data.Interfaces;
using flight.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Repisotories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        ///  
        /// </summary>
        /// <param name="appDbContext"></param>
        public AirportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Airport list
        /// </summary>
        IEnumerable<Airport> IAirportRepository.Airports =>  _appDbContext.Airports.OrderBy(a => a.AirportId);

        /// <summary>
        /// To Add a new airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        int IAirportRepository.Add(Airport airport)
        {
            try
            {
                _appDbContext.Airports.Add(airport);
                _appDbContext.SaveChanges();
                return airport.AirportId;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
            
        }

        /// <summary>
        /// Get Airport by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Airport IAirportRepository.GetAirport(int Id)
        {
            return _appDbContext.Airports.FirstOrDefault(a => a.AirportId == Id);
        }

        /// <summary>
        /// To Update a new airport
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        int IAirportRepository.Update(Airport airport)
        {
            try
            {

                var airportDB = _appDbContext.Airports.Single(a => a.AirportId == airport.AirportId);
                airportDB.Latitude = airport.Latitude;
                airportDB.Longitude = airport.Longitude;
                airportDB.Name = airport.Name;
                _appDbContext.SaveChanges();
                return airport.AirportId;
            }
            catch (Exception)
            {

                return -1;
                throw;
            }
        }
    }
}
