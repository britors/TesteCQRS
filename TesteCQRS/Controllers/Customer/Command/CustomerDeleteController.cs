using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer;

namespace TesteCQRS.Controllers.Customer.Command
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerDeleteController : ControllerBase
    {
        [HttpDelete]
        public async Task<IActionResult> Delete([FromServices] IMediator mediator, [FromBody] CustomerDeleteCommand command)
        {
            try
            {
                var result = await mediator.Send(command);
                return Ok(result);
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
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
