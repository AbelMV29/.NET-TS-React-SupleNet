using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;
using System.Net;
using System.Security.Claims;

namespace SupleNet.Application.UseCases.ItemCart.Queries.GetCartUser
{
    public class GetCartUserQueryHandler : IRequestHandler<GetCartUserQuery, Result<GetCartUserQueryResponse>>
    {
        private readonly IItemCartRepository _itemCartRepository;
        private readonly IHttpContextAccessor _httpContext;

        private GetCartUserQueryResponse _emptyValue = new GetCartUserQueryResponse([], 0);

        public GetCartUserQueryHandler(IItemCartRepository itemCartRepository, IHttpContextAccessor httpContext)
        {
            _itemCartRepository = itemCartRepository;
            _httpContext = httpContext;
        }

        public async Task<Result<GetCartUserQueryResponse>> Handle(GetCartUserQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = new Guid(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var itemsCart = await _itemCartRepository.GetCartUser(currentUserId);

            if (itemsCart.Length == 0)
                return Result<GetCartUserQueryResponse>.Success(_emptyValue, null, HttpStatusCode.OK);

            var itemsResult = itemsCart.Select(i =>
            {
                return new GetCartUserQueryResponse.GetCartUserItemQueryResponse(i.Product.Id, i.Product.Name, i.Product.Price, i.Product.Price*i.Quantity, i.Quantity);
            }).ToArray();

            var totalPrice = itemsResult.Sum(i => i.SubTotalPrice);

            var result = new GetCartUserQueryResponse(itemsResult, totalPrice);

            return Result<GetCartUserQueryResponse>.Success(result, null, HttpStatusCode.OK);
        }
    }

}
