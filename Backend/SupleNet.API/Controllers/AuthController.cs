using MediatR;
using Microsoft.AspNetCore.Mvc;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.Responses.Identity;
using SupleNet.Application.UseCases.AppUser.Command.Login;
using SupleNet.Application.UseCases.AppUser.Command.Register;

namespace SupleNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType<Result<Unit>>(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        [HttpPost("register")]
        public async Task<ActionResult<Result<Unit>>> Register([FromBody] RegisterCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result.IsSuccess)
                    return StatusCode((int)result.HttpStatusCode, result);
                return StatusCode((int)result.HttpStatusCode, result.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [ProducesResponseType<Result<LoginResponse>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<ActionResult<Result<LoginResponse>>> Login([FromBody] LoginCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if(result.IsSuccess)
                    return StatusCode((int)result.HttpStatusCode, result);
                return StatusCode((int)result.HttpStatusCode, result.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
