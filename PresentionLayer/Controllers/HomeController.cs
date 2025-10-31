
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
        [HttpPut("customers/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command)
        {

            if (id != command.Id)
            {
                return BadRequest("ID in URL does not match ID in body");
            }
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return NoContent();

        }


    }
}
