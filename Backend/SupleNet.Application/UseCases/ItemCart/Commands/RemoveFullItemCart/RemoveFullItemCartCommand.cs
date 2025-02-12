using MediatR;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.ItemCart.Commands.RemoveFullItemCart
{
    public record RemoveFullItemCartCommand(Guid ProductId) : IRequest<Result<Unit>>;
}
