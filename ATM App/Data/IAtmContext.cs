using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IAtmContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<Operation> Operations { get; set; }
        DbEntityEntry<T> Entry<T>(T t) where T : class;
        int SaveChanges();
    }
}
