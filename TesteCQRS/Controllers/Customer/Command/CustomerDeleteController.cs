using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteCQRS.Application.Commands.Customer;
using TesteCQRS.Shared.Utils;

namespace TesteCQRS.Controllers.Customer.Command
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerDeleteController : ControllerBase
    {
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromServices] IMediator mediator, [FromBody] CustomerDeleteCommand command)
        {
            try
            {
                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                var erros = ValidatorErrorsUtil.GetErrorsFromValidationException(ex);
                return BadRequest(erros);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
