using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.UseCases.Brand.Commands.AddBrand;
using SupleNet.Application.UseCases.Brand.Queries.GetBrands;

namespace SupleNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType<Result<GetBrandsQueryResponse[]>>(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<Result<GetBrandsQueryResponse[]>>> GetBrands([FromQuery]GetBrandsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode((int)result.HttpStatusCode, result);
        }

        [Authorize(Roles = "Admin")]
        [ProducesResponseType<Result<Unit>>(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<Unit>> AddBrand(AddBrandCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
                return StatusCode((int)result.HttpStatusCode, result);
            return StatusCode((int)result.HttpStatusCode, result.Message);
        }
    }
}
