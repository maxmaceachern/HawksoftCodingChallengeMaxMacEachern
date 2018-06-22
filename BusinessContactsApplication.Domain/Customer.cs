using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessContactsApplication.Domain
{
    public class Customer
    {
		[Key] public int CustomerId { get; set; }
	    public string FirstName { get; set; }
		public string LastName { get; set; }
		[ForeignKey("Address")] public int AddressId { get; set; }
	    public Address Address { get; set; }
	}
}
