using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly DatabaseContext context;


    public CustomerController(DatabaseContext context)
    {
        this.context = context;
    }

    [HttpGet]   //Fazendo o método GET
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        return this.context.Customer.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomers(int id)
    {
        var customer = this.context.Customer.Find(id);
        if (customer == null)
        {
            return NotFound(); //Erro 404 na API
        }
        return customer;
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer) 
    {
        if(customer == null)
        {
            return BadRequest();
        }
        this.context.Customer.Add(customer);
        this.context.SaveChanges();

        return CreatedAtAction(nameof(GetCustomers), new {id = customer.Id}, customer); 


    }

    [HttpDelete("{id}")]
    public ActionResult<Customer> DeleteCustomer(int id)
    {
        var customer = this.context.Customer.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        this.context.Customer.Remove(customer);
        this.context.SaveChanges();
        return NoContent();
        //return customer;
    }




}





