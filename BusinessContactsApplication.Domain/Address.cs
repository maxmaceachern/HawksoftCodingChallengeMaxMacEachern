using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessContactsApplication.Domain
{
    public class Address
    {
		[Key] public int AddressId { get; set; }
	    public string Street { get; set; }
	    public string City { get; set; }
	    public string State { get; set; }
	    public string Country { get; set; }
	    [ForeignKey("Customer")] public Customer Customer { get; set; }
    }
}
