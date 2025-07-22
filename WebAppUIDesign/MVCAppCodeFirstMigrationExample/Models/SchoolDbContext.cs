using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCAppCodeFirstMigrationExample.Migrations;

namespace MVCAppCodeFirstMigrationExample.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext() : base("ConStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDbContext, Configuration>());
        }

        public DbSet<Student> Students { get; set; }
    }
}