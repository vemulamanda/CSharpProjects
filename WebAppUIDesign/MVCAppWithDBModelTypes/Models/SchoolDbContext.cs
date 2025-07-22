using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace MVCAppWithDBModelTablePerHierarchyTypeExample.Models
{
    public class SchoolDbNewContext : DbContext
    {
        public SchoolDbNewContext() : base("ConStr")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SchoolDbNewContext>());
        }
        //-----------------------------------------------------------------------------------------------

        //Table per hierarchy: Just write below one line of code

        // public DbSet<Person> People { get; set; }

        //-----------------------------------------------------------------------------------------------
        //Table per type: write below line of code

        //The below piece of code should be written if you want to create a seperate tables for teacher and student and
        //this will also create pimary and foriegn key relationship between people table and student and teacher table, 
        //where people table being the primary and teacher and student tables being secondary.
        //If you want single table with all values in it you can just write "public DbSet<Person> People { get; set; }", this piece of code.


        /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
              modelBuilder.Entity<Student>().ToTable("Student");
              modelBuilder.Entity<Teacher>().ToTable("Teacher");
          }

          public DbSet<Person> People { get; set; }
        */
        //-----------------------------------------------------------------------------------------------

        //Table for concrete: Write below code.

        //This below piece of code is used in table per concrete type.
        //When you use this a seperate table s created for teacher, student  and people table is not created.
        //This is becoz, the concrete model creates student and teacher tables with all the values(like creating seperate tables for each.)
        //and also you should make person class as abstract, so it it wont allow inheritance, and the id should not be auto generated, so used data annotations.
        // and now id should added manually for every record by you.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Student");
            });

            modelBuilder.Entity<Teacher>().Map(m => 
            {
                m.MapInheritedProperties();
                m.ToTable("Teacher");
            });
        }

        public DbSet<Person> People { get; set; }

    }
}