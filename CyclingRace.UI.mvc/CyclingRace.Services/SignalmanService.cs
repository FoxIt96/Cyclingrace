using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyclingRace.Core;
using CyclingRace.Model;
using Microsoft.EntityFrameworkCore;

namespace CyclingRace.Services
{
    public class SignalmanService(CyclingRaceDbContext dbContext)
    {
        public IList<Signalman> Find()
        {
            return dbContext.Signalmen
                .Include(a => a.Locatie)
                .ToList();
        }

        public Signalman? Get(int id)
        {
            return dbContext.Signalmen
                .Include(a => a.Locatie)
                .FirstOrDefault(p => p.Id == id);
        }

        public Signalman? Create(Signalman signalman)
        {
            dbContext.Signalmen.Add(signalman);
            dbContext.SaveChanges();

            return signalman;
        }

        public Signalman? Update(int id, Signalman signalman)
        {
            var dbSignalman = dbContext.Signalmen.FirstOrDefault(p => p.Id == id);

            if (dbSignalman is null)
            {
                return null;
            }

            dbSignalman.FirstName = signalman.FirstName;
            dbSignalman.LastName = signalman.LastName;
            dbSignalman.LocationId = signalman.LocationId;

            dbContext.SaveChanges();

            return signalman;
        }

        public void Delete(int id)
        {
            var dbSignalman = dbContext.Signalmen.FirstOrDefault(p => p.Id == id);

            if (dbSignalman is null)
            {
                return;
            }

            dbContext.Signalmen.Remove(dbSignalman);

            dbContext.SaveChanges();
        }
    }
}
