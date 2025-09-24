
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
            try
            {
                var customers = await _mediator.Send( new GetCustomersQuery());
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
               
        }

    }
}
