using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCAppOneToOneRelationExample.Models
{
    public class FamilyDbContext : DbContext
    {
        public FamilyDbContext() : base("ConStr")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<FamilyDbContext>());
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Spouse> Spouse { get; set; }
    }
}