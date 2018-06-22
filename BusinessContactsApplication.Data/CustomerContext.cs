using BusinessContactsApplication.Domain;
using Microsoft.EntityFrameworkCore;

// I didn't implement the actual SQL database here, but I did want to include the DbContext to indicate that is something I need to address
// within the scope of the problem. I'd also like to create a separate dbSet to represent the join between the customer and the address as that
// is not indicated in the way I've set up my models so far.

namespace BusinessContactsApplication.Data
{
    public class CustomerContext : DbContext
    {
		public DbSet<Customer> Customers { get; set; }
	    public DbSet<Address> Addresses  { get; set; }
    }
}
