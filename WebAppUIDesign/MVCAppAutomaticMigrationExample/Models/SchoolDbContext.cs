using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCAppAutomaticMigrationExample.Migrations;

namespace MVCAppAutomaticMigrationExample.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext() : base("ConStr")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDbContext, Configuration>());
        }

        public DbSet<Student> students { get; set; }
    }
}