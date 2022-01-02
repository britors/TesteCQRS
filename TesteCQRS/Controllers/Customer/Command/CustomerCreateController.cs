using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using FluentValidation;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer;
using Microsoft.AspNetCore.Http;
using TesteCQRS.Utils;

namespace TesteCQRS.Controllers.Customer.Command
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerCreateController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IMediator mediator, [FromBody] CustomerCreateCommand command)
        {
            try
            {
                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                var erros = ValidatorErrorsUtil.GetErrorsFromException(ex);
                return BadRequest(erros);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
