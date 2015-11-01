using System.Data.Entity;

namespace BDSA2015.Lecture08.WebApi.Models
{
    public partial class Northwind : DbContext, INorthwind
    {
        public Northwind()
            : base("name=Northwind")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Id)
                .IsFixedLength();
        }
    }
}
