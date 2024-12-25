using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.UseCases.Category.Commands.AddCategory;

namespace SupleNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "Admin")]
        [ProducesResponseType<Result<Unit>>(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<Unit>> AddCateogory(AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return StatusCode((int)result.HttpStatusCode, result);
            return StatusCode((int)result.HttpStatusCode, result.Message);
        }
    }
}
