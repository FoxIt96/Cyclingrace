using CyclingRace.Model;
using Microsoft.EntityFrameworkCore;

namespace CyclingRace.Core
{
    public class CyclingRaceDbContext : DbContext
    {
        public CyclingRaceDbContext(DbContextOptions<CyclingRaceDbContext> options) : base(options) { }

        public DbSet<Signalman> Signalmen => Set<Signalman>();
        public DbSet<Location> Locations => Set<Location>();


        public void Seed()
        {
            Signalmen.AddRange(new List<Signalman>
            {
                new Signalman { FirstName = "nick", LastName = "Devos", LocationId = 1 },
                new Signalman{FirstName = "nick2", LastName = "Devos"},
                new Signalman{FirstName = "nick2", LastName = "Devos"}
            });

            Locations.AddRange(new List<Location>
            {
                new Location { Name = "Kasseistrook", Address = "Guido Gezellestraat 28", Description = "test"},
                new Location { Name = "Kasseistrook2", Address = "Guido Gezellestraat 28", Description = "test2"},
                new Location { Name = "Kasseistrook3", Address = "Guido Gezellestraat 28", Description = "test3" },
                new Location { Name = "Kasseistrook4", Address = "Guido Gezellestraat 28", Description = "test4" },
                new Location { Name = "Kasseistrook5", Address = "Guido Gezellestraat 28", Description = "test5" }
            });

            SaveChanges();

        }
    }
}
