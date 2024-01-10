using CyclingRace.Core;
using CyclingRace.Model;

namespace CyclingRace.Services
{
    public class LocationService(CyclingRaceDbContext dbContext)
    {
        public IList<Location> Find()
        {
            return dbContext.Locations
                .ToList();
        }

        public Location? Get(int id)
        {
            return dbContext.Locations
                .FirstOrDefault(l => l.Id == id);
        }

        public Location? Create(Location location)
        {
            dbContext.Locations.Add(location);
            dbContext.SaveChanges();
            return location;
        }

        public Location? Update(int id, Location location)
        {
            var dbLocation = dbContext.Locations.FirstOrDefault(p => p.Id == id);

            if (dbLocation is null)
            {
                return null;
            }

            dbLocation.Name = location.Name;
            dbLocation.Address = location.Address;
            dbLocation.Description = location.Description;
            dbContext.SaveChanges();

            return location;
        }

        public void Delete(int id)
        {
            var dbPerson = dbContext.Locations.FirstOrDefault(p => p.Id == id);

            if (dbPerson is null)
            {
                return;
            }

            dbContext.Locations.Remove(dbPerson);

            dbContext.SaveChanges();
        }
    }
}
