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
        public AircraftRepository(AppDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext; 
        }

        IEnumerable<Aircraft> IAircraftRepository.Aircrafts =>
            _appdbcontext.Aircrafts.OrderBy(a=>a.AircraftId);

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

        Aircraft IAircraftRepository.GetAircraft(int Id)
        {
            var aircraft = _appdbcontext.Aircrafts.FirstOrDefault(a => a.AircraftId == Id);
            return aircraft;
        }

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
            catch (Exception)
            {
                return -1;
                throw;
            }
           
        }
    }
}
