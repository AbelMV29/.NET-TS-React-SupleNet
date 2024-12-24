using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.UseCases.Product.Commands.AddProduct;
using SupleNet.Application.UseCases.Product.Queries.GetProducts;

namespace SupleNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles ="Admin")]
        [ProducesResponseType<Result<Unit>>(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<Result<Unit>>> Add([FromForm] AddProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return StatusCode((int)result.HttpStatusCode, result);
            return StatusCode((int)result.HttpStatusCode, result.Message);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result<GetProductsQueryResponse>>> GetAll([FromQuery] GetProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode((int)result.HttpStatusCode, result);
        }
    }
}
