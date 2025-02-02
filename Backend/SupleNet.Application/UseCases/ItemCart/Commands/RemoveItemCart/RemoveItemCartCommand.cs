using MediatR;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.ItemCart.Commands.RemoveItemCart
{
    public record RemoveItemCartCommand(Guid ProductId) : IRequest<Result<Unit>>;
}
