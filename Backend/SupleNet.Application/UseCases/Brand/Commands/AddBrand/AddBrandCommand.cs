using MediatR;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.Brand.Commands.AddBrand
{
    public record AddBrandCommand(string Name) : IRequest<Result<Unit>>;
}
