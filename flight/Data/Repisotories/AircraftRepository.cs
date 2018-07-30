using flight.Data.Interfaces;
using flight.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Data.Repisotories
{
    public class AircraftRepository : IAircraftRepository
    {
        private AppDbContext _appdbcontext;

        /// <summary>
        /// initialisation DBcontext
        /// </summary>
        /// <param name="appdbcontext"></param>
        public AircraftRepository(AppDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext; 
        }

        /// <summary>
        /// Aircraft list
        /// </summary>
        IEnumerable<Aircraft> IAircraftRepository.Aircrafts =>
            _appdbcontext.Aircrafts.OrderBy(a=>a.AircraftId);

        /// <summary>
        /// To Add a new aircraft
        /// </summary>
        /// <param name="aircraft"></param>
        /// <returns></returns>
        int IAircraftRepository.Add(Aircraft aircraft)
        {
            try
            {
                _appdbcontext.Aircrafts.Add(aircraft);
                _appdbcontext.SaveChanges();
                return aircraft.AircraftId;
            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
        }

        /// <summary>
        /// Get aircraft by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Aircraft IAircraftRepository.GetAircraft(int Id)
        {
            var aircraft = _appdbcontext.Aircrafts.FirstOrDefault(a => a.AircraftId == Id);
            return aircraft;
        }

        /// <summary>
        /// To Update a  aircraft
        /// </summary>
        /// <param name="aircraft"></param>
        /// <returns></returns>
        int IAircraftRepository.Update(Aircraft aircraft)
        {
            try
            {
                var aircraftDB = _appdbcontext.Aircrafts.Single(a => a.AircraftId == aircraft.AircraftId);
                aircraftDB.FuelComsumption = aircraft.FuelComsumption;
                aircraftDB.Name = aircraft.Name;
                _appdbcontext.SaveChanges();
                return aircraftDB.AircraftId;
            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
        }

        /// <summary>
        /// To Delete aircraft
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Remove(int Id)
        {
            try
            {
                var aircraftDB = _appdbcontext.Aircrafts.FirstOrDefault(a => a.AircraftId == Id);
                if (aircraftDB == null)
                    return false;
                _appdbcontext.Remove(aircraftDB);
                _appdbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            
        }
    }
}
