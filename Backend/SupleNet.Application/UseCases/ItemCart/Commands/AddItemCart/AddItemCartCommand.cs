using MediatR;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.ItemCart.Command.AddItemCart
{
    public record AddItemCartCommand(Guid ProductId) : IRequest<Result<Unit>>;
}
