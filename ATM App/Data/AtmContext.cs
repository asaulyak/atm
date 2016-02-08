using Data.DbInitializer;
using Data.Entities;
using System.Data.Entity;

namespace Data
{
    public class AtmContext : DbContext, IAtmContext
    {
        public AtmContext() : base("AtmContext") {
            Database.SetInitializer(new AtmDbInitializer());
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}
