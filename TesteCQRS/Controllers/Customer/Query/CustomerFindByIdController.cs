using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteCQRS.Application.Queries.Customer;

namespace TesteCQRS.Controllers.Customer.Query
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerFindByIdController : ControllerBase
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAll([FromServices] IMediator mediator, Guid Id)
        {
            try
            {
                var query = new CustomerFindByIdQuery { Id = Id };
                var items = await mediator.Send(query);
                return Ok(items);
            }
            catch (ValidationException ex)
            {
                var erros = ex.Errors
                            .GroupBy(failure => failure.PropertyName)
                            .ToDictionary(failures => failures.Key,
                                                failures => failures
                                                .Select(failure => failure.ErrorMessage));
                return BadRequest(erros);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
