using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteCQRS.Application.Queries.Customer;

namespace TesteCQRS.Controllers.Customer.Query
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerFindAllController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetById([FromServices] IMediator mediator)
        {
            try
            {
                var query = new CustomerFindAllQuery();
                var items = await mediator.Send(query);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
