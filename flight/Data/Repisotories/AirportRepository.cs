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
        public AirportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        IEnumerable<Airport> IAirportRepository.Airports =>  _appDbContext.Airports.OrderBy(a => a.AirportId); 
       

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

        Airport IAirportRepository.GetAirport(int Id)
        {
            return _appDbContext.Airports.FirstOrDefault(a => a.AirportId == Id);
        }

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
