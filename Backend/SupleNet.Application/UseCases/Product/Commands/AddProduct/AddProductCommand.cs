using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.Product.Commands.AddProduct
{
    public record AddProductCommand
        (string Name, string Description, decimal Price, List<Guid> categoriesId, List<IFormFile> files) : IRequest<Result<Unit>>;
}
 