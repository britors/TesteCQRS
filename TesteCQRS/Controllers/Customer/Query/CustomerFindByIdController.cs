using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteCQRS.Application.Queries.Customer;
using TesteCQRS.Shared.Utils;

namespace TesteCQRS.Controllers.Customer.Query
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerFindByIdController : ControllerBase
    {
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                var erros = ValidatorErrorsUtil.GetErrorsFromValidationException(ex);
                return BadRequest(erros);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
