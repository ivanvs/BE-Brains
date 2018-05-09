using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace tour_of_hereos.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("DataAccessConnection")
        {
            Database.SetInitializer<DataAccessContext>(new DropCreateDatabaseIfModelChanges<DataAccessContext>());
        }

        public DbSet<Hero> Heroes { get; set; }
    }
}