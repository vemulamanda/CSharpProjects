using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAppWithCodeFirstApproach.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext() : base("ConStr")
        {
            //if you add new property to your model classes after the creation of database, you will see an error when you build the application,
            //use below code to create database if not exists, but it works only when you dont have any database with same name.
            //Database.SetInitializer(new CreateDatabaseIfNotExists<StoreDbContext>());

            //if you add new property to your model classes after the creation of database,
            //you can use below code if you want to create new database if model classes change(like adding new property)
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StoreDbContext>());

            //if you want to recreate database irrespective of weather database exista or not, use below,
            //Database.SetInitializer(new DropCreateDatabaseAlways<StoreDbContext>());

            //if you dont want to make any more changes and moving your app to prod, use below:
            Database.SetInitializer<StoreDbContext>(null);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}