using Project_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL
{
    public class DuiklocatiesBeheerEntities: DbContext
    {
        public DuiklocatiesBeheerEntities() : base("DuiklocatiesBeheerDBConnectionString")
        {

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Preview> Previews { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationCustomer> LocationCustomers { get; set; }

    }
}
