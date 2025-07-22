using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCAppCodeFirstWithDBParametersSPExample.Models
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("ConStr")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SchoolDBContext>());
        }

        public DbSet<Student> Students { get; set; }

        //This below part of code will create stored procedures for you when this piece of code is run. it will map to student model and create SP.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().MapToStoredProcedures();

            //If you want to give your own names to stored procedures, please write below lines of code:
            modelBuilder.Entity<Student>().MapToStoredProcedures(S => S.Insert(X => X.HasName("Insert_Student")));
            modelBuilder.Entity<Student>().MapToStoredProcedures(S => S.Update(X => X.HasName("Update_Student")));
            modelBuilder.Entity<Student>().MapToStoredProcedures(S => S.Delete(X => X.HasName("Delete_Student")));
        }
    }
}