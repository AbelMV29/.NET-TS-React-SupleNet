using MediatR;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.ItemCart.Queries.GetCartUser
{
    public record GetCartUserQuery : IRequest<Result<GetCartUserQueryResponse>>
    {
    }

}
