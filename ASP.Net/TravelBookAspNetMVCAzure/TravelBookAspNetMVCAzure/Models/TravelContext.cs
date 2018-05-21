using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TravelBookAspNetMVCAzure.Models
{
    public class TravelContext : DbContext
    {
        public TravelContext() : base("Data Source=tcp:travelbookserver.database.windows.net,1433;Initial Catalog=TravelBookDB;User ID=mujo;Password=Fata123.") { }


        
        //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka
       /* public DbSet<Student> Student { get; set; }
        public DbSet<UpisNaPredmet> UpisNaPredmet { get; set; }
        public DbSet<Predmet> Predmet { get; set; }*/
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
     /*   protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/
    }
}