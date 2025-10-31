
using BusinessLogicLayer.Commends.Custmers;
using BusinessLogicLayer.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Get Customers")]
        public async Task<IActionResult> GetCustomers()
        {
           
                var customers = await _mediator.Send( new GetCustomersQuery());
                return Ok(customers);
            
               
        }
        [HttpGet("customers/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
           
                var customer = await _mediator.Send(new GetCustomerQuery(id));
                return Ok(customer);
          

        }
        [HttpPost("customers")]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand command)
        {
           
                var customer = await _mediator.Send(command);
                return Ok(customer);
            

        }


    }
}
