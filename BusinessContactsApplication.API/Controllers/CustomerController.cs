using System.Collections.Generic;
using System.Linq;
using BusinessContactsApplication.Data;
using BusinessContactsApplication.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// Each of the four http verbs are reprented here and I also included Get by Id. If I had more time, I would
// have wanted to add an additional API for the address, so you could update the address without interacting with
// the customer object at all (assuming you'd just pass the API call the Id)

namespace BusinessContactsApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[EnableCors("https://localhost:44343/")]
    public class CustomerController : ControllerBase
    {
		private readonly CustomerContext _context;

	    public CustomerController(CustomerContext context)
	    {
			_context = context;
	    }
	    
	    // GET api/customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
	        return _context.Customers.ToList();
        }

        // GET api/customer/{id}
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
	        var customer = _context.Customers.Find(id);
	        if (customer == null)
	        {
		        return NotFound();
	        }
			return customer;
        }

		// POST api/customers
		[HttpPost]
        public void Post([FromBody] Customer customer)
		{
			_context.Customers.Add(customer);
			_context.Addresses.Add(customer.Address);
		}

		// PUT api/customers/{id}
		[HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
		{
			var updatedCustomer = _context.Customers.Find(id);
			if (updatedCustomer == null)
			{
				return NotFound();
			}

			updatedCustomer.FirstName = customer.FirstName;
			updatedCustomer.LastName = customer.LastName;
			updatedCustomer.Address = customer.Address;
			updatedCustomer.AddressId = customer.AddressId;
			_context.Customers.Update(updatedCustomer);
			_context.SaveChanges();
			return NoContent();
		}

		// DELETE api/customers/{id}
		[HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
	        var customerToRemove = _context.Customers.Find(id);
	        if (customerToRemove == null)
	        {
		        return NotFound();
	        }

	        var address = _context.Addresses.Find(customerToRemove.AddressId);
	        _context.Customers.Remove(customerToRemove);
	        _context.Addresses.Remove(address);
	        _context.SaveChanges();
	        return NoContent();
		}
    }
}
