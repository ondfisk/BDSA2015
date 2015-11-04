using System.Data.Entity;

namespace BDSA2015.Lecture09.WebApi.Models
{
    public partial class CustomerContext : DbContext, ICustomerContext
    {
        public CustomerContext()
            : base("name=Customers")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
